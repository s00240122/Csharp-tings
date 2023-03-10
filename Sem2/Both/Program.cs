using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Both
{
    internal class Program
    {
        public static Dictionary<double, char> markToGrade = new Dictionary<double, char>
        {
            // upper bound for each grade
            [40] = 'F',
            [50] = 'E',
            [60] = 'D',
            [70] = 'C',
            [80] = 'B',
            [100] = 'A',
        };

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() { };

            Console.WriteLine(DetermineGradeV3(45));
        }

        public static char DetermineGradeV3(double mark)
        {
            char grade = mark switch
            {
                double m when m < 40 => 'F',
                double m when m < 50 => 'E',
                double m when m < 60 => 'D',
                double m when m < 70 => 'C',
                double m when m < 80 => 'B',
                double m when m <= 100 => 'A',
                _ => 'F'  // default case, is an error somehow occurs
            };

            return grade;
        }

        public static char DetermineGradeV2(double mark)
        {
            char grade = 'F';  // default

            foreach (var pair in markToGrade)
            {
                grade = pair.Value;

                if (mark < pair.Key)
                    break;
            }

            return grade;
        }

        public static bool IsStudentNum(string input)
        {
            Regex re = new Regex(@"^[sS]\d{8}$");

            if (re.IsMatch(input))
                return true;
            else
                return false;
        }

        public static bool IsDoubleTo100(string input)
        {
            Regex re = new Regex(@"^([0-9]{1,2}){1}(\.[0-9]{1,})?$");
            // probably not the best regext but it works

            if (re.IsMatch(input) == true || input == "100")
                return true;
            else
                return false;
        }
    }

    public class Student
    {
        public string number { get; set; }
        public double mark { get; set; }
        public char grade { get; set; }

        public Student(string number, double mark, char grade)
        {
            this.number = number;
            this.mark = mark;
            this.grade = grade;
        }

        public override string ToString()
        {
            return $"Student number: {this.number}\nMark: {this.mark}\nGrade: {this.grade}";
        }
    }
}
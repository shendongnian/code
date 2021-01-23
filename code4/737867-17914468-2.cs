     public class Course
        {
            public string CourseName;
            public int CourseNumber;
            public int StudentsNumber;
            public string TeacherName;
            public string ClassNumber;
            public void AddCourse()
            {
                Console.WriteLine("Enter the Course's name, course's number, students number, teacher's name, and class' number\n");
                this.CourseName = Console.ReadLine().ToString();
                this.CourseNumber = int.Parse(Console.ReadLine());
                this.StudentsNumber = int.Parse(Console.ReadLine());
                this.TeacherName = Console.ReadLine().ToString();
                this.ClassNumber = Console.ReadLine().ToString();
    
            }
        }

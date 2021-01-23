    class Course
    {
        internal string CourseName {get; set;}
        public IEnumerable<Student> Students { get; set; }
        public Course(string c_name, IEnumerable<Student> students)
        { 
            this.CourseName = c_name;
            this.Students = students;
        }
        public class Student
        {
            internal string StudentName {get; set;}
            internal IEnumerable<int> GradesList {get; set;}
            public Student(string studentName, IEnumerable<int> grades)
            {
                this.StudentName = studentName;
                this.GradesList = grades;
            }
        }
    }
    class Program
    {
        static void Main (string[] args)
        {
            var courseCS = new List<Course.Student>();
            courseCS.Add(new Course.Student("Bob", new List<int> {100, 99, 85}));
            var courseJava = new List<Course.Student>();
            courseJava.Add(new Course.Student("Bobi", new List<int> { 99, 90, 88 }));
            var courseC = new List<Course.Student>();
            courseC.Add(new Course.Student("Roni", new List<int> {  }));
            var courseSQL = new List<Course.Student>();
            courseSQL.Add(new Course.Student("Sean", new List<int> { 75, 62, 55 }));
            List <Course> list = new List<Course>
            {
                new Course ("C#", courseCS),  
                new Course ("Java", courseJava),    
                new Course ("C", courseC), 
                new Course ("SQL", courseSQL)
            };
            foreach (var course in list)
            {
                Console.WriteLine(course.CourseName);
                foreach (var student in course.Students)
                {
                    Console.WriteLine(student.StudentName);
                    foreach (var grade in student.GradesList)
                    {
                        Console.WriteLine(grade);
                    }
                }
            }
        }
    }

    class Course
    {
        internal string CourseName { get; set; }
        public Student s { get; set; }
        public class Student
        {
            internal string StudentName { get; set; }
            internal IEnumerable<int> GradesList { get; set; }
            public int ShowGrade(int index)
            {
                if (GradesList == null)
                    throw new NullReferenceException();
                return GradesList.ElementAt<int>(index);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Course> list = new List<Course>()
        {
            new Course () { CourseName = "C#", 
                s =  new Course.Student() { StudentName = "Bob", 
                                                                                GradesList = new List<int>() { 100, 99, 85 }}},  
            new Course () { CourseName = "Java", 
                s =  new Course.Student() { StudentName = "Bobi", 
                                                                                GradesList = new List<int>(){ 99, 90, 88 }}},
            new Course (){ CourseName = "C", 
                s = new Course.Student() { StudentName = "Roni", 
                                                                                GradesList = new List<int>()}},
            new Course (){ CourseName = "SQL", 
                s = new Course.Student() { StudentName = "Sean", 
                                                                                GradesList = new List<int>(){ 75, 62, 55 }}}
        };
            Console.WriteLine(list[0].s.ShowGrade(1));
            Console.ReadKey();
        }
    }

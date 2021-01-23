    public class Course
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }

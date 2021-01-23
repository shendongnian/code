    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
    public class Student
    {
        public Course Course { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public bool HasScholarship { get; set; }
    }

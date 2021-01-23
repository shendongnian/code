    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    }

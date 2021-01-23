    public class Course
    {
        public String Name { get; set; }
    }
    public class CoursesViewModel
    {
        private IList<Course> courses;
        public IList<Course> Courses{
          get { return this.courses ?? (this.courses = new List<Course>()); }
          set { this.courses = value; }
        }
    }

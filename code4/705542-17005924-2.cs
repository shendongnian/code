    public class Transcript
    {
        private List<Course> courses_ = new List<Course>();
        public IEnumerable<Course> Courses {get { return courses_; }
        public IEnumerable<Course> GetCoursesFor(int year, int quarter)
        {
            return courses_.Where(course => course.Year == year && course.Quarter == quarter);
        }
        public void AddCourse(Course course)
        {
            courses_.Add(course);
        }
    }
    public class Course
    {
        public int Year {get; private set;}
        public int Quarter {get; private set;}
        // ... other members
    }

    public class Teacher
        {
            public int TeacherID { get; set; }
    
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            public IQueryable<Course> Courses { get; set; }
    
            public Teacher()
            {
                Courses = new IQueryable<Course>();
            }
        } 
    public class TeacherEditor
        {
            public Teacher Teacher { get; set; }
            public int[] SelectedCourseIds { get; set; }
            public List<Course> CourseList 
            {
                get { return Teacher.Courses.ToList(); }
                set { Teacher.Courses = value.ToList(); }
            }
        }

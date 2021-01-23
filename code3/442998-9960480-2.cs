    public class Student
    {
        ....
        public virtual ICollection<Course> Courses { get; set; } // Many courses
    }
    
    public class Course
    {
        ....
        public virtual ICollection<Student> Students { get; set; } // Many students
    }

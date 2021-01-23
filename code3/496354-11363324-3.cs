    public class Course
    {
      [Key]
      public virtual int CourseID {get; set;}
      public virtual string CourseName {get; set;}
      public virtual Assignment {get; set;}
    }

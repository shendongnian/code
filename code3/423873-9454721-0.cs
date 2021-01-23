    public class Person
    {
      public int PersonID { get; set; }
    
      public virtual ICollection<PersonCourse> PersonCourses { get; set; }
    }
    
    public class Course
    {
      public int CourseID { get; set; }
    
      public virtual ICollection<PersonCourse> PersonCourses { get; set; }
    }
    
    public class PersonCourse
    {
      [Key, Column(Order = 0)]
      public int PersonID { get; set; }
      [Key, Column(Order = 1)]
      public int CourseID { get; set; }
      [Key, Column(Order = 2)]
      public int AnotherUniqueParameter { get; set; }
    
      // Navigation Properties
      public virtual Person { get; set; }
      public virtual Course { get; set; }
    }

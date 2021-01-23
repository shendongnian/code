    public class CoursesContext: DbContext
    {
       public DbSet<Assignment> Assignments {get; set;}    
       public DbSet<Course> Courses {get; set;}
    }

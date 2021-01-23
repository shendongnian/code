    class MyDbContext : DBContext
    {
       public DbSet<Course> Courses{get;set;}
       public DbSet<Assignment> Assignments{get;set;}
    }

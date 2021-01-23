    public class YourDbContext : DbContext
    {
        ....
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(x => x.Courses).WithMany(x => x.Students)
                .Map(m =>
                {
                    m.ToTable("Enrollment"); // Relationship table name
                    m.MapLeftKey("StudentID"); // Name of column for student IDs
                    m.MapRightKey("CourseID"); // Name of column for course IDs
                });
        }
    }

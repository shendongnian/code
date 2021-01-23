    public class StudentClassContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    
        public StudentClassContext()
        {
           
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
               .HasMany(aStudent => aStudent.Classes) // A student can have many classes
               .WithMany(aClass => aClass.Students)); // Many classes can have many students
             //.Map(c => c.ToTable("StudentClass); // Set the mapping table to this name
        }
    
    }

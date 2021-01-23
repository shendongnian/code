    // Interface for Repository:
        public interface IStudentRepository : IDisposable
        {
            IEnumerable<Student> GetStudents();
            Student GetStudentByID(int studentId);
            void InsertStudent(Student student);
            void DeleteStudent(int studentID);
            void UpdateStudent(Student student);
            void Save();
        }
----------
    // Context to Generate Database:
        public class SchoolContext : DbContext
        {
            public DbSet<Course> Courses { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }
            public DbSet<Instructor> Instructors { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Person> People { get; set; }
            public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Entity<Instructor>()
                    .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);
                modelBuilder.Entity<Course>()
                    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                    .Map(t => t.MapLeftKey("CourseID")
                        .MapRightKey("PersonID")
                        .ToTable("CourseInstructor"));
                modelBuilder.Entity<Department>()
                    .HasOptional(x => x.Administrator);
            }
        }

    public class Student
    {
        public virtual int StudentId { get; set; }
        public virtual string StudentName { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Course
    {
        public virtual int CourseId { get; set; }
        public virtual string CourseName { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Enrollment
    {
        public virtual int StudentId { get; set; }
        public virtual int CourseId { get; set; }
        public virtual string Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
    public class ManyMany : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(student => student.StudentId);
            modelBuilder.Entity<Course>()
                .HasKey(course => course.CourseId);
            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new { enrollment.StudentId, enrollment.CourseId } );
            modelBuilder.Entity<Student>()
                .HasMany(student => student.Enrollments)
                .WithRequired()
                .HasForeignKey(enrollment => enrollment.StudentId);
            modelBuilder.Entity<Course>()
                .HasMany(course => course.Enrollments)
                .WithRequired()
                .HasForeignKey(enrollment => enrollment.CourseId);
        }
    }

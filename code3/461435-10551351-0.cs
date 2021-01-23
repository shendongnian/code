    public abstract class Lesson
    {
        public Guid ID { get; set; }
    }
    public class RecurringLesson : Lesson
    {
    }
    public class MyContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecurringLesson>().ToTable("RecurringLessons");
        }
    }

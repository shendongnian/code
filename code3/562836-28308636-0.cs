    public class MyContext : DbContext, IDisposedTracker
    {
    
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public bool IsDisposed { get; set; }
    }

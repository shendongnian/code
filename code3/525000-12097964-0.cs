    public class ReportClassContext : DbContext
    {
        public DbSet<ReportClass> ReportClasses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          modelBuilder.Entity<ReportClass>().ToTable("ReportClassesRealTable");
        }
    }

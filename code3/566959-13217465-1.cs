    namespace CvGenerator.Models
    {
        public class LogInEntities:DbContext
        {
            List<DbSet> lgn;
            public LogInEntities()
            {
                 lgn = new List<DbSet>();
            }
            public List<DbSet> LogIn { get{return lgn;} set{lgn=value;} }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
                modelBuilder.Entity<LogIn>().ToTable("LogInData");
                base.OnModelCreating(modelBuilder);
            }
        }
    
    }

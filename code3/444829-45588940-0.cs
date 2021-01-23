    public class ApplicationContext : DbContext, IDbContext
        {
            public ApplicationContext() : base("ApplicationContext")
            {
                 
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                Database.SetInitializer<ApplicationContext>(null);
                base.OnModelCreating(modelBuilder);
            }
         }

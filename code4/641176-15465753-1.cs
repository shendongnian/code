    public class Context: DbContext
        {
            public Context()
            {
                base.Configuration.LazyLoadingEnabled = false;
                base.Configuration.ProxyCreationEnabled = false;
                base.Configuration.ValidateOnSaveEnabled = false;
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
            public DbSet<LocationEntity> LocationEntities{ get; set; }
        }

    MySuperContext : DbContext
    {
        // All DbSet<> s from your different contexts have to be referenced here once, you will only use this class for the migrations.
    
        public MySuperContext() : base("YourConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySuperContext, MyMigrationsConfiguration>());
        }
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
             Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, ContextConfiguration>());
    
             base.OnModelCreating(modelBuilder);
          }

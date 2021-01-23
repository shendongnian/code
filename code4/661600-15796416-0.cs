    class CreateAndMigrateDatabaseInitializer<TContext, TMigrationsConfiguration> : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext> 
        where TContext : DbContext
        where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _config;
        public CreateAndMigrateDatabaseInitializer()
        {
            _config = new TMigrationsConfiguration();
        }
        public CreateAndMigrateDatabaseInitializer(string connectionStringName)
        {
            Contract.Requires(!string.IsNullOrEmpty(connectionStringName), "connectionStringName");
            _config = new TMigrationsConfiguration
            {
                TargetDatabase = new DbConnectionInfo(connectionStringName)
            };
        }
        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            Contract.Requires(context != null, "context"); 
            var migrator = new DbMigrator(_config);
            migrator.Update();
            // move on with the 'CreateDatabaseIfNotExists' for the 'Seed'
            base.InitializeDatabase(context);
        }
        protected override void Seed(TContext context)
        {
        }
    }

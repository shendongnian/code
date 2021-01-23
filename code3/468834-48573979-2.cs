    internal sealed class DataDbConfiguration : DbMigrationsConfiguration<DataDbContext>
    {
        private readonly bool _isInitialized;
        public DataDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            var migrator = new DbMigrator(this);
            _isInitialized = migrator.GetDatabaseMigrations().Any();
        }
        protected override void Seed(DataDbContext context)
        {
            InitializeDatabase(context);
        }
        public void InitializeDatabase(DataDbContext context)
        {
            if (!_isInitialized)
            {
                if (context.Database.Connection.ConnectionString.Contains("localdb"))
                {
                    DataSeedInitializer.Seed(context); // Seed Initial Test Data
                }
                else
                {
                    // Do Seed Initial Production Data here
                }
            }
            else
            {
                // Do any recurrent Seed here
            }
        }
    }

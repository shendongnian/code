    class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            this.SetDatabaseInitializer(new DropCreateDatabaseAlways<MyDbContext>());
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }

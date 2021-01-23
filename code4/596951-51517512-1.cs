    [DbConfigurationType(typeof(DbContextConfiguration))]
    public static class Startup
    {
    }
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            // This is needed to force the EntityFramework.SqlServer DLL to be copied to the bin folder
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }

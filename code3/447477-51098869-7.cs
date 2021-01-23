    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.Dev.ZdbTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            var cg = GetSqlGenerator("Oracle.ManagedDataAccess.Client");
            SetSqlGenerator("Oracle.ManagedDataAccess.Client", new CustomOracleSqlCodeGen(cg));
        }
        // ...

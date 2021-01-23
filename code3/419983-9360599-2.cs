    public static class Entities
    {
        public static MyEntities Create()
        {
             var builder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MyEntities"].ConnectionString);
             var sqlConnection = new SqlConnection(builder.ProviderConnectionString);
             var profiledConnection = new EFProfiledDbConnection(sqlConnection, MiniProfiler.Current);
    
             return profiledConnection.CreateObjectContext<MyEntities>();
        }
    }

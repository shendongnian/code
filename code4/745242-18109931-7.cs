    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single, AutomaticSessionShutdown = true)]
    public class SampleService : ISampleService
    {
        SampleEntities datacontext = null;
        public void Login(string user, string password, int entityID)
        {
           if(CheckLoginData(user, password))
           {
             InitDataContext(entity_id);
           }
        }
        private void InitDataContext(int entityID)
        {
           var connectionString = GetConnectionStringFromEntityID(entityID);
           datacontext = new SampleEntities(connectionString);
        }
        private string GetConnectionStringFromEntityID(int entityID)
        {
            var providerName = "System.Data.SqlClient";
            var serverName = "localhost";
            var databaseName = GetDatabaseNameFromEntityID(entityID);
            var sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;
            var providerString = sqlBuilder.ToString();
            var entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = providerName;
            entityBuilder.ProviderConnectionString = providerString;
            
            entityBuilder.Metadata = @"res://*/SampleDatabase.csdl|
                            res://*/SampleDatabase.ssdl|
                            res://*/SampleDatabase.msl";
            return entityBuilder.ToString();
        }
    }

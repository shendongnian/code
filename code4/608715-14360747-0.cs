    public static class ConnectionManager
        {
            public static string GetSqlConnectionString()
            {
    
                var serverName = @"" + ConfigurationManager.AppSettings["ServerName"];
                var databaseName = ConfigurationManager.AppSettings["DatabaseName"];
                var username = ConfigurationManager.AppSettings["Username"];
                var password = ConfigurationManager.AppSettings["Password"];
    
                SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
    
                providerCs.DataSource = serverName;
                providerCs.InitialCatalog = databaseName;
                //providerCs.IntegratedSecurity = true;
                //providerCs.UserInstance = true;
                providerCs.UserID = username;
                providerCs.Password = password;
                var csBuilder = new EntityConnectionStringBuilder();
    
                csBuilder.Provider = "System.Data.SqlClient";
                csBuilder.ProviderConnectionString = providerCs.ToString();
    
                csBuilder.Metadata = string.Format("res://{0}/yourDataBase.csdl|res://{0}/yourDataBase.ssdl|res://{0}/yourDataBase.msl",
                    typeof(yourDataBaseEntities).Assembly.FullName);
    
                return csBuilder.ToString();
            }
        }

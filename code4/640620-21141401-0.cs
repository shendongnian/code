     public AdventureWorksEntities(string server, string databaseName, string user, string password)
            :base(new System.Data.EntityClient.EntityConnectionStringBuilder
            {
                Metadata = "res://*",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder 
                {
                    InitialCatalog = databaseName,
                    DataSource = server,
                    IntegratedSecurity = false,
                    UserID = user,
                    Password = password,
                    
                }.ConnectionString
            }.ConnectionString) 
        {
            
        }

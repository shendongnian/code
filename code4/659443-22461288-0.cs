     public static class ConfigurationService
        {
            static public string ConnectionString
            {
    
                get
                {
    
                    try
                    {               
                        // Specify the provider name, server and database.
                        string providerName = "System.Data.SqlClient";
                        string serverName = @"192.168.1.106\SQLEXPRESS";
                        string databaseName = "MyDatabaseName";
    
                        // Initialize the connection string builder for the
                        // underlying provider.
                        var sqlBuilder = new SqlConnectionStringBuilder();
    
                        // Set the properties for the data source.
                        sqlBuilder.DataSource = serverName;
                        sqlBuilder.InitialCatalog = databaseName;
                        sqlBuilder.IntegratedSecurity = false;
                        sqlBuilder.UserID = "Bob";
                        sqlBuilder.Password = "Bob1234";
                        sqlBuilder.MultipleActiveResultSets = true;
                        sqlBuilder.ApplicationName = "EntityFramework";
    
                        // Build the SqlConnection connection string.
                        string providerString = sqlBuilder.ToString();
    
                        // Initialize the EntityConnectionStringBuilder.
                        var entityBuilder = new EntityConnectionStringBuilder();
    
                        //Set the provider name.
                        entityBuilder.Provider = providerName;
    
                        // Set the provider-specific connection string.
                        entityBuilder.ProviderConnectionString = providerString;                 
    
                        // Set the Metadata location.
                        entityBuilder.Metadata = @"res://*/Models.MyDatabaseNameModel.csdl|res://*/Models.MyDatabaseNameModel.ssdl|res://*/Models.MyDatabaseNameModel.msl";
    
                        var result = entityBuilder.ToString();
                        return result;
                    }
                    catch (Exception)
                    {
    
                    }
    
                    return string.Empty;
                }
    
            }
        }

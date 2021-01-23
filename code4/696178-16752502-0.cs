    internal static EntityConnection CreateEntityConnection()
                {
                    // Start out by creating the SQL Server connection string
                    SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
    
                    // Set the properties for the data source. The IP address network address
                    sqlBuilder.DataSource = System.Configuration.ConfigurationManager.AppSettings["Connection"];
                    // The name of the database on the server
                    sqlBuilder.UserID = "sa";
                    sqlBuilder.Password = "12345";
                    sqlBuilder.InitialCatalog = "DatabaseName";
                    sqlBuilder.IntegratedSecurity = true;
                    sqlBuilder.MultipleActiveResultSets = true;
                    // Now create the Entity Framework connection string
                    EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                    //Set the provider name.
                    entityBuilder.Provider = "System.Data.SqlClient";
                    // Set the provider-specific connection string.
                    entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
    
                    // Set the Metadata location. 
                    entityBuilder.Metadata = @"res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl";
    
                    // Create and entity connection
                    EntityConnection conn = new EntityConnection(entityBuilder.ToString());
                    return conn;
                }

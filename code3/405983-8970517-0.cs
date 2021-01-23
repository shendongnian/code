    public string GetConnectionString()
        {
            string connectionString = new EntityConnectionStringBuilder
            {
                Metadata = "res://*/Data.System.csdl|res://*/Data.System.ssdl|res://*/Data.System.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new SqlConnectionStringBuilder
                {
                    InitialCatalog = ConfigurationManager.AppSettings["SystemDBName"],
                    DataSource = ConfigurationManager.AppSettings["SystemDBServerName"],
                    IntegratedSecurity = false,
                    UserID = ConfigurationManager.AppSettings["SystemDBUsername"],
                    Password = ConfigurationManager.AppSettings["SystemDBPassword"],
                    MultipleActiveResultSets = true,
                }.ConnectionString
            }.ConnectionString;
            return connectionString;
        }

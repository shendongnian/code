    public class ConnectionProvider
        {
            DbConnection conn;
            string connectionString;
            DbProviderFactory factory;
    
            // Constructor that retrieves the connectionString from the config file
            public ConnectionProvider()
            {
                this.connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();
                factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[0].ProviderName.ToString());
            }
    
            // Constructor that accepts the connectionString and Database ProviderName i.e SQL or Oracle
            public ConnectionProvider(string connectionString, string connectionProviderName)
            {
                this.connectionString = connectionString;
                factory = DbProviderFactories.GetFactory(connectionProviderName);
            }
    
            // Only inherited classes can call this.
            public DbConnection GetOpenConnection()
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = this.connectionString;
                conn.Open();
    
                return conn;
            }
    
        }

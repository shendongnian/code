    public class BaseContext : DbContext
    {
        public BaseContext(string nameOrConnectionString)
            : base(CreateConnection(nameOrConnectionString), true)
        {
        }
    
        private static EntityConnection CreateConnection(string connectionString)
        {
            // Create a (plain old database) connection using the shared connection string.
            DbConnection dbConn = Database.DefaultConnectionFactory.CreateConnection(
                ConfigurationManager.ConnectionStrings["SharedConnection"].ConnectionString);
    
            // Create a helper EntityConnection object to build a MetadataWorkspace out of the
            // csdl/ssdl/msl parts of the generated EF connection string for this DbContext.
            EntityConnection wsBuilder = new EntityConnection(connectionString);
        
            // Merge the specific MetadataWorkspace and the shared DbConnection into a new EntityConnection.
            return new EntityConnection(wsBuilder.GetMetadataWorkspace(), dbConn);
        }
    }

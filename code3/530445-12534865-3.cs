    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetValueFor(Type type)
        {
            // use reflection to get name of type
            // look up connection string based on the name
            // return the connection string
        }
    }
    ...
    public class SomeRepository:ISomeRepository
    {
        public SomeRepository(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionString = connectionStringProvider.GetValueFor(this.GetType());
        }
    }

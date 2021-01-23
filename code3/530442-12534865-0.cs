    public class ConnectionStringProvider<T> : IConnectionStringProvider<T>
    {
        public string Value
        {
            // use reflection to get name of T
            // look up connection string based on the name
            // return the connection string
        }
    }
    ...
    public class SomeRepository:ISomeRepository
    {
        public SomeRepository(IConnectionStringProvider<SomeRepository> connectionStringProvider)
        {
            this.connectionString = connectionStringProvider.Value;
        }
    }

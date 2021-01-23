    public interface IService
    {
        void Execute(Action<IDbConnection> command);
        T Execute<T>(Func<IDbConnection, T> command);
    }
    
    public sealed class ConnectionManager : IService
    {
        public const int MaxConnections = 10;
        
        private readonly string _connectionString;
        private readonly SemaphoreSlim _workers = new SemaphoreSlim(0, MaxConnections);
        
        public ConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public void Execute(Action<IDbConnection> command)
        {
            lock(_workers)
            {
                using(var connection = new OdbcConnection(_connectionString))
                {
                    connection.Open();
                    command(connection);
                }
            }
        }
        
        public T Execute<T>(Func<IDbConnection, T> command)
        {
            lock(_workers)
            {
                using(var connection = new OdbcConnection(_connectionString))
                {
                    connection.Open();
                    return command(connection);
                }
            }
        }
    }

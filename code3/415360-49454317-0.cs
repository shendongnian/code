    public class ConnectionFactory
    {
        private readonly string _connectionName;
        public ConnectionFactory(string connectionName)
        {
            _connectionName = connectionName;
        }
        public IDbConnection NewConnection() => new SqlConnection(_connectionName);
        #region Connection Scopes
        public TResult Scope<TResult>(Func<IDbConnection, TResult> func)
        {
            using (var connection = NewConnection())
            {
                connection.Open();
                return func(connection);
            }
        }
        public async Task<TResult> ScopeAsync<TResult>(Func<IDbConnection, Task<TResult>> funcAsync)
        {
            using (var connection = NewConnection())
            {
                connection.Open();
                return await funcAsync(connection);
            }
        }
        public void Scope(Action<IDbConnection> func)
        {
            using (var connection = NewConnection())
            {
                connection.Open();
                func(connection);
            }
        }
        public async Task ScopeAsync<TResult>(Func<IDbConnection, Task> funcAsync)
        {
            using (var connection = NewConnection())
            {
                connection.Open();
                await funcAsync(connection);
            }
        }
        #endregion Connection Scopes
    }

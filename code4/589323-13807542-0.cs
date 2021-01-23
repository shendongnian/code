    public class MyDbConnection : IDbConnection
    {
        private IDbConnection _connection;
    
        public MyDbConnection(IDbConnection connection)
        {
           _conn = connection;
        }
    
        // here goes your property
        public string DatabaseType { get; set; }
    
        public void Close()
        {
            _connection.Close();
        }
    
        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _connection.BeginTransaction(il);
        }
    
        // implement other methods by delegating work to _connection
    }

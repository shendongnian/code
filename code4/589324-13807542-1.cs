    public class MyDbConnection : IDbConnection
    {
        private IDbConnection _connection;
    
        public MyDbConnection(IDbConnection connection)
        {
           _connection = connection;
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
    
        // implement other IDbConnection members by delegating work to _connection
    }

    internal class OpenedContext : IDisposable
    {
        private OracleConnection _connection;
        public OpenedContext(OracleConnection conn) {
            _connection = conn;
            if (_connection.State != System.Data.ConnectionState.Open) _connection.Open();            
        }
        public void Dispose() {
            if (_connection.State != System.Data.ConnectionState.Closed) _connection.Close();
        }
    }

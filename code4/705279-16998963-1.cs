    interface IConnection {}
    class Connection : IConnection
    {
        // internal details of the connection; should not be public.
        protected object _client;
        // base class constructor
        public Connection(object client) { _client = client; }
    }
    class AuthenticatedConnection : IConnection
    {
        private readonly IConnection connection;
        public AuthenticatedConnection2(string token, IConnection connection)
        {
            // use token etc
        }
    }

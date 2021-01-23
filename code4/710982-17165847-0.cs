    class Connection
    {
        private readonly string param1;
        private readonly string param2;
        private  static readonly IList<Connection> connections = new List<Connection>();
    
        private Connection()
        {
            //Prevent instantiation
        }
    
        private Connection(string param1, string param2)
        {
            this.param1 = param1;
            this.param2 = param2;
        }
    
        public static Connection getInstance(string param1, string param2)
        {
    
            lock (connections)
            {
                var connection = connections.FirstOrDefault(c => c.param1.Equals(param1) && c.param2.Equals(param2));
                if (connection != null)
                {
                    return connection;
                }
                else
                {
                    var new_conn = new Connection(param1, param2);
                    connections.Add(new_conn);
                    return new_conn;
                } 
            }
        }
    
    }

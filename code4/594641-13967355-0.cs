    public class Connection
    {
        public Connection()
        {
        }
        public Connection(string parameter)
            : this()
        {
            string connectionString = GetConnection(parameter);
        }
    }

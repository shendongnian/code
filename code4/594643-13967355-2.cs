    public class Connection
    {
        public Connection()
            : this(GetConnectionString())
        {
        }
        public Connection(string parameter)
            : this()
        {
        }
        public static string GetConnectionString()
        {
            //...
        }
    }

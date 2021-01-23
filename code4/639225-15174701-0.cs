    public class DatabaseManager
    {
        private static DatabaseManager _instance;
        private DatabaseManager()
        {
        }
        static DatabaseManager()
        {
            _instance = new DatabaseManager();
        }
        public DatabaseManager Instance
        {
            get { return _instance; }
        }
        private string GetConnectionString()
        {
            return Properties.Settings.Default.MyConnectionString;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(GetConnectionString();
        }
    }

    public class DataManager
    {
        private static DataManager _instance;
        
        private DataManager() {}
        
        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataManager();
                return _instance;
            }
        }
        
        public DbConnection GetConnection()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
        }
        
        ...
    }

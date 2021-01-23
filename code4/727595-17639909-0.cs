    public class DbConnection
    {
        ...
        public MySqlConnection Connection { get; set; }
        public DbConnection()
        {
            Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mysqlconnect"].ConnectionString);
            ....
        }

    public class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
        }
    }

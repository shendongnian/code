    public class ConnectionUtility
    {
        private static con = new SqlConnection();
    
        public static SqlConnection GimmeConnection()
        {
            return con;
        }
    }

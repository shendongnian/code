    public class ConnectionUtility
    {
        private static SqlConnection con = new SqlConnection();
    
        public static SqlConnection GimmeConnection()
        {
            return con;
        }
    }

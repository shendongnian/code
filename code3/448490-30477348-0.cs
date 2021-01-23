    public static SqlConnection getConnection()
    {
            string conn = string.Empty;
            conn = System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            SqlConnection aConnection = new SqlConnection(conn);
            return aConnection;
    }

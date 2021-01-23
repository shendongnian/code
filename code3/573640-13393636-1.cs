    class Common
    {
        private string connectionString;
        public static string ConnectionString {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public static DbConnection OpenConnection()
        {
            OracleConnection con = new OracleConnection(ConnectionString);
            con.Open();
            return con;
        }
    }

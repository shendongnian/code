    public static class SqlExpress
    {    
        public static string ConnectionString { get; set; }
        
        public static SqlConnection DatabaseConnection()
        {            
            SqlConnection linkToDB = new SqlConnection(ConnectionString);
            return linkToDB;
        }

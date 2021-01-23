    public class DatabaseConnection 
    {
        
        private static DbConnection createSQlConnectionWithDB1()
        {
            // create a connection with DB1
            return new SqlConnection();
        }
        private static DbConnection createSQlConnectionWithDB2()
        {
           // create a connection with DB2
            return new SqlConnection();
        }
        public  static DbConnection createConnection(string typeOfConnection)
        {
            if (typeOfConnection.Equals("DB1"))
                return createSQlConnectionWithDB1();
            if (typeOfConnection.Equals("DB2"))
                return createSQlConnectionWithDB2();
            return null;
        }
    }

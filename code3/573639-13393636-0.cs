    class Common
    {
        public static string ConnectionString {get;set;}
         // ^^ this is an "automatically implemented property", but there's
         // a compiler-generated field behind it implicitly
        public static DbConnection OpenConnection()
        {
            OracleConnection con = new OracleConnection(ConnectionString);
            con.Open();
            return con;
        }
    }

    public static class Connector
    {
        static SqlConnection con = new SqlConnection(...); //return type object, 
                                                           //just for example, choose more 
                                                           //appropriate type for you.
    
        public static object GetData(string query)
        {
           con.Open();
           
           //run query and retrieve results
    
           con.Close();
        }
    }

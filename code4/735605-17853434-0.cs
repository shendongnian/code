    public class sqlConn
    { 
            public SqlConnection myConnection = new SqlConnection("user id=ID;password=PASS;server=SERVER;database=DB;");
    
            public void connectionMethod()
            {          
                try
                {
                    myConnection.Open();
                }
                catch
                {
                    //Here goes error handling...
                }                 
        }
    }

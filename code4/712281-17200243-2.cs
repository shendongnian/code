    public class MySqlClass : IDisposable
    {
        private SqlConnection conn { get; set; }
        public MySqlClass(string connectionstring) 
        {
            conn = new SqlConnection(connectionstring);
        }
    
        public void DoSomething1(string tsql)
        {
            using (SqlCommand comm = new SqlCommand(tsql, conn)) {
                conn.Open();           
            }
        }
        public void DoSomething2(string tsql)
        {
            using (SqlCommand comm = new SqlCommand(tsql, conn)) {
                conn.Open();           
            }
        }
        //DISPOSE STUFF HERE    
    }
    

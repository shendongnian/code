    public abstract class DALBase
    {
        private const string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jasper\Desktop\AutoReg\AutoReg.accdb;";
        
        protected DataSet Fill(OleDbCommand command)
        {
            DataSet ds = new DataSet();
            using (OleDbConnection myConn = new OleDbConnection(connStr))
            {
                command.Connection = myConn;
                myConn.Open();
                
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {                                    
                    adapter.Fill(ds);                                    
                }
            }
            return ds;
        }
        
        protected void ExecuteNonQuery(OleDbCommand command)
        {
            using (OleDbConnection myConn = new OleDbConnection(connStr))
            {
                command.Connection =  myConn;                            
                myConn.Open();
                command.ExecuteNonQuery();
            }
        }
        
        // put any other methods you need here    
        
    }

    using(OleDbConnection oleDbConn = new OleDbConnection())
    {
       oleDbConn.Open(); 
       using (OleDbCommand oleDbCmd = new OleDbCommand())
       {
          using (OleDbDataAdapter oleDbAdapter = new OleDbDataAdapter())
          {
             //More code can go here.
          }
       }
       oleDbConn.Close();      
    }

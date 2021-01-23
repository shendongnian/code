    using (OleDbConnection cn = new OleDbConnection(connectionString))
    {
     try
     {
       cn.Open();
       //db operations 
     }
     catch(Exception ex)
     {
     
     }
    }

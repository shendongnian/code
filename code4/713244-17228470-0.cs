    using (var con = new SqlConnection(//connection string)
      {
        using (var cmd = new SqlCommand(storedProcname, con))
         {
           try{
               con.open();
               //data reader code
           }
           catch
           {
    
           }
         }
      }

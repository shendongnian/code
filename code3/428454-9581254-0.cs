    using (SqlConnection  connection= new SqlConnection(connectionstring))
       {
         connection.Open();
         SqlTransaction transaction = connection.BeginTransaction();
         try
         {
            SqlCommand command = new SqlCommand("proc1",connection);
            //execute the above command
            command.CommandText="proc2";
            //execute command again for proc2
            transaction.Commit();                   
         }
         catch
         {
           //Roll back the transaction.
           transaction.Rollback();
         }  
       }

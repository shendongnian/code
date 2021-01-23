    using(var trans = new TransactionScope())
    {
      try
      {
         //your setup code goes here
        sqlConnection1.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
    
        trans.Complete();
       }
       catch(Exception)
       {
        //handle exception
       }
    }

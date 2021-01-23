    using(DbConnection connection = ...)    
    {    
        connection.Open();    
        using(DbTransaction transaction = connection.BeginTransaction(...))    
        {
          try{
            ... update ...
            ... another update ...
    
            transaction.Commit(); 
          }catch(Exception){
           // transaction rolled back here if an Exception is thrown before the call to Commit()
            transaction.Rollback()
          }   
        }     
    } // connection closed here

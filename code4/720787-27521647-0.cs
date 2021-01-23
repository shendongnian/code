    using (var dbContextTransaction = context.Database.BeginTransaction()) 
    {
      try
      {
        //Some stuff
        dbContextTransaction.Commit(); 
      } 
      catch (Exception) 
      { 
        dbContextTransaction.Rollback(); 
      }
    } 

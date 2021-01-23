     using (var context = new MyContext(this._connectionString))
     {
    
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
             try
             {
                  // do-stuff //
                  context.SaveChanges();
                  ///////////////////////
                  //if any exception happen, changes wont be saved unless Commit is called 
                  //NB!!!!!!
                  //----------------------
                  dbContextTransaction.Commit();
             }
             catch (Exception ex)
             {
                  dbContextTransaction.Rollback();
                  //log why it was rolled back
                  Logger.Error("Error during transaction,transaction rollback", ex);
             }
        }
    }

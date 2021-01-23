    try
    {
       // do-stuff
       context.SaveChanges();
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

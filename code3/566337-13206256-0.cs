    void Application_BeginRequest()
    {
        // Start your unit of work, open a session and begin a transaction
    }
    
    // Do all of your work ( Read, insert, update, delete )
    
    void Application_EndRequest()
    {
        try
        {
            // UnitOfWork.Current.Transaction.Commit();
        }
        catch( Exception e )
        {
            // UnitOfWork.Current.Transaction.Rollback();
        }
    }

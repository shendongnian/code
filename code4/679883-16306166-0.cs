    try
    {
        // ...
    }
    catch(Exception e)
    {
        if (ErrorHandler.IsCriticalException(e))
        {
            throw;
        }
    
        // log it or show something to user
    }

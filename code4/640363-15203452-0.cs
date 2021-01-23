    public static void ErrorHandlingWrapper(Action DoWork)
    {
        try { 
            DoWork();
        }
        catch(Exception ex)
        {
            Logger.log(ex);
    
            // actually will be Fault Exception but you get the idea.
            throw;
        }
    }

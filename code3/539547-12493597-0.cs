    public void DoMyInternetThing(int numberOfAttemptsRemaining)
    {
        try 
        {
             //do stuff
        }
        catch (ConnectionException) 
        {
            if (numberOfAttemptsRemaining > 0)
                DoMyInternetThing(--numberOfAttemptsRemaining);  
    
            throw;
        }
    }

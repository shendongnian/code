    public void DoMyInternetThing(int numberOfAttemptsRemaining)
    {
        try 
        {
             //do stuff
        }
        catch (ConnectionException) 
        {
            if (numberOfAttemptsRemaining <= 0)
                throw new SomethingBadHappenedException();
            
            DoMyInternetThing(numberOfAttemptsRemaining - 1);  
        }
    }

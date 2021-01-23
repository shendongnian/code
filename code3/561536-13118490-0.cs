    public int A
    {
        get 
        {
           _log.Debug("Property A accessed by some user");
           _readingsCount++;
           // your logic goes here
           return _a;
        }    
    }

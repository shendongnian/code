    ...
    #if PRO_VERSION 
        SomethingOnlyInProVersion(); 
    #elif
        SomethingOnlyInFreeVersion(); 
    #endif 
    ...
    
    
    #if PRO_VERSION 
    public void SomethingOnlyInProVersion()
    {
    }
    #elif
    public void SomethingOnlyFreeVersion()
    {
    }
    #endif 

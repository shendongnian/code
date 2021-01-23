    public void Work(string input = DefaultInput)
    {
        //do stuff
    }
…
    public void WorkWrapper(int someParameter, string inputOverride = null)
    {
        //do initialization
        if (inputOverride == null) Work();
        else Work(inputOverride);    
    }

    Work(string input = DefaultInput)
    {
        //do stuff
    }
…
    WorkWrapper(int someParameter, string inputOverride = null)
    {
        //do initialization
        if (inputOverride == null) Work();
        else Work(inputOverride);    
    }

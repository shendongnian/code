    public string Nothing() 
    {
        if (FlagClass.Done == null) 
        {
            FlagClass.Done = false;
        }
        while (!FlagClass.Done) 
        {
            System.Threading.Thread.Sleep(1000);
        }
        return "done";
    }
    public string AnotherMethod()
    {
        FlagClass.Done = true;
        return "hello";
    }

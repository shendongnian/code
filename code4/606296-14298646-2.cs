    try
    {
        //work
    }
    catch (HandleableException e)
    {
        e.Handle();  // this calls a **virtual** method, each override does what's relevant
        Logger.log(e.GetType().Name + " " + e);
        DoSomething();
    }

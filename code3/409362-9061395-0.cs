    try
    {
        if(Monitor.TryEnter(myLockObject))
        {
            DoSomething(); // main code
        }
    }
    finally
    {
        Monitor.Exit(myLockObject);
    }

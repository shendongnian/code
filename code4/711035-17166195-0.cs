    System.Object obj = (System.Object)x;
    System.Threading.Monitor.Enter(obj);
    try
    {
        DoSomething();
    }
    finally
    {
        System.Threading.Monitor.Exit(obj);
    }

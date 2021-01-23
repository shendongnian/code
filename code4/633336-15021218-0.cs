    object x = new object();
    bool lockTaken = false;
    // lock
    try{
        System.Threading.Monitor.Enter(x, ref lockTaken)
        DoSomeThing();
    }
    finally
    {
       if (lockTaken)
       {
            System.Threading.Monitor.Exit(x);
       }
    }

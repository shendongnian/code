        if(Monitor.TryEnter(myLockObject))
        {
           try
           {
               DoSomething(); // main code
           }
           finally
           {
               Monitor.Exit(myLockObject);
           }
        }

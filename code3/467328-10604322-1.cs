    public static bool hasExecuted = false;
    
    static readonly object lockObject = new object();
    
    static void Method()
    {
        lock(lockObject)
        {
            if(!hasExecuted)
            {
                // run code
                hasExecuted = true;
            }
        }
    }

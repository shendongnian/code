    public static void MethodA(object lockObject)
    {
        lock(lockObject)
        {
            //code that needs to be accessed by just one thread
        }
    }
    
    public static void MethodB(object lockObject)
    {
        lock(lockObject)
        {
            //code that needs to be accessed by just one thread
        }
    }

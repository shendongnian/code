    public static void WriteError(string errorMessage)
    {
        var mut = new Mutex(true, "LogMutexName");
    
        try
        {   
            // Wait until it is safe to enter.
            mut.WaitOne();
    
            // here you open write close your file
        }
        finally
        {
            // Release the Mutex.
            mut.ReleaseMutex();
        }   
    }

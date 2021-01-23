    try
    {
        if(Monitor.TryEnter(obj, 2000))
        {
            try
            {
                // code here
            }
            finally
            {
                Monitor.Exit(obj);
            }
        }
        else
        {
            throw new Exception("Can't acquire lock");
        }
    }
    catch
    {
        // log
    }

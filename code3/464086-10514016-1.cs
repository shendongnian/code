    foreach(item in IEnumerable<ISample> items)
    {
        try
        {
            // Do stuff with item
        }
        finally
        {
            IDisposable amIDisposable = item as IDisposable;
            if(amIDisposable != null)
                amIDisposable.Dispose();  
        }
    }

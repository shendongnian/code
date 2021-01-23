    foreach(item in IEnumerable<ISample> items)
    {
        try
        {
            // Do stuff with item
        }
        finally
        {
            // ISample also implements IDisposable, must dispose!
            item.Dispose();
        }
    }

    try
    {
        {
            Disposable dispObj = new Disposable();
            try
            {
                dispObj.Process();
            }
            finally
            {
                if (dispObj != null)
                    ((IDisposable)dispObj).Dispose();
            }
        }
    }
    catch (Exception ex)
    {
        // Do something
    }

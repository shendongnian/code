    WCFProxy clientProxy = null;
    try
    {
        clientProxy = new WCFProxy();
        clientProxy.SomeCall();
        clientProxy.Close();
    }
    catch (Exception)
    {
        if (clientProxy != null)
        {
            clientProxy.Abort();
        }
        throw;
    }

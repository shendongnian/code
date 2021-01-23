    private void GetProjectInformation(object obj)
    {
        ...
        connectionManager.GetProjectInfo(filter);
        var mre = new ManualResetEvent( false );
        connectionManager.InfoReceived += delegate( ... )
        {
            ...
            mre.Set();
        };
        mre.WaitOne();
    }

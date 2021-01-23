    private void GetProjectInformation(object obj)
    {
        ...
        ProjectConnectionManager connectionManager = new ProjectConnectionManager();
        var mre = new ManualResetEvent( false );
        connectionManager.InfoReceived += delegate( ... )
        {
            ...
            mre.Set();
        };
        connectionManager.GetProjectInfo(filter);
        mre.WaitOne();
    }

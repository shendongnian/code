        var host = new ServiceHost(...);
        var waitHandle = new ManualResetEvent(false);
        var serviceThread = new System.Threading.Thread(() =>
            {
                host.Open();
                waitHandle.Set();
            });
        serviceThread.Start();
        if( !waitHandle.WaitOne(MAX_TIME_TO_WAIT))
        {
            // not started...
        }
        else ..

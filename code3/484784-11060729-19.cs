    public void GetConnection(string thread, Action<dynamic> callback)
    {
        //I found that ops is not being used
        //ParallelOptions ops = new ParallelOptions();
        if(thread.Equals("one"))
        {
            Parallel.For(0, 1, i =>
            {
                callback(InitializeCRMService());
            });
        }
        else if (thread.Equals("multi"))
        {
            ThreadPool.QueueUserWorkItem
            (
                 new WaitCallback
                 (
                     (_) =>
                     {
                          callback(InitializeCRMService());
                     }
                 )
            );
        }
    }

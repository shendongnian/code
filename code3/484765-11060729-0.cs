    public void GetConnection(string thread)
    {
        ParallelOptions ops = new ParallelOptions();
        if(thread.Equals("one"))
        {
        Parallel.For(0, 1, i =>
        {
            dynamic serviceObject = InitializeCRMService();       
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
                          dynamic serviceObject = InitializeCRMService();
                     }
                 )
            );
        }
    }

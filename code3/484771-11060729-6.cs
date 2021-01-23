    public void GetConnection(string thread)
    {
        //I found that ops is not being used
        //ParallelOptions ops = new ParallelOptions();
        if(thread.Equals("one"))
        {
            Parallel.For(0, 1, i =>
            {
                //It seems to me a good idea to take the same path here too
                //dynamic serviceObject = InitializeCRMService();
                Store(InitializeCRMService());
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
                          Store(InitializeCRMService());
                     }
                 )
            );
        }
    }

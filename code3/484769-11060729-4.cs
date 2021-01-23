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
    private void Store(dynamic serviceObject)
    {
        //store serviceObject somewhere you can use it later.
        //Depending on your situation you may want to
        // set a flag or use a ManualResetEvent to notify
        // that serviceObject is ready to be used.
        //Any pre proccess can be done here too.
        //Take care of thread affinity,
        // since this may come from the ThreadPool
        // and the consuming thread may be another one,
        // you may need some synchronization.
    }

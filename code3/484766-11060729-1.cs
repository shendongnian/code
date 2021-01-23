    public void GetConnection(string thread)
    {
        //I found that ops is not being used
        //ParallelOptions ops = new ParallelOptions();
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
                          //You don't really need to have a variable
                          /*dynamic serviceObject =*/ InitializeCRMService();
                     }
                 )
            );
        }
    }

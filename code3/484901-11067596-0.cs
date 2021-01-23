    public IOrganizationService GetConnection(bool multi)
    {
        var waitHandle = new ManualResetEvent(false);
        dynamic result = null;
        if(!multi)
        {
            Parallel.For(0, 1, i =>
            {
               result = InitializeCRMService();
               waitHandle.Set();
            });
        }
        else
        {
            ThreadPool.QueueUserWorkItem
            (
                new WaitCallback
                (
                    (_) =>
                    {
                        result = InitializeCRMService();
                        waitHandle.Set();
                    }
                )
            );
        }
        //We wait until the job is done...
        waitHandle.WaitOne();
        return result as IOrganizationService; //Or the appropiate casting
    }

    public void GetConnection(bool multi, Action<IOrganizationService> callback)
    {
        if (ReferenceEquals(callback, null))
        {
            throw new ArgumentNullException("callback");
        }
        if(!multi)
        {
            Parallel.For(0, 1, i =>
            {
                callback(InitializeCRMService() as IOrganizationService);
                //Or instead of using "as", use an adecuate casting
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
                          callback(InitializeCRMService() as IOrganizationService);
                          //Or instead of using "as", use an adecuate casting
                     }
                 )
            );
        }
    }

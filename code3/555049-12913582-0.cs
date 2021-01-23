    Task.Factory.StartNew (() =>
    {
       System.Threading.Thread.Sleep (5000);
    })
    . ContinueWith (() =>
    {
         / / Code after 5 seconds
    }
    TaskScheduler.FromCurrentSynchronizationContext ());

    for (int i = 0; i < 100; i++)
    {
        Task.Factory.StartNew(obj => DoUIStuff(), 
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    private void DoUIStuff()
    {
        //...
    }

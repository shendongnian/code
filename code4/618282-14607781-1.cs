    IsBusy = true;
    Task.Factory.StartNew(() => 
    { 
      // Do work. 
    })
    .ContinueWith(t=>IsBusy=false, 
                            TaskScheduler.FromCurrentSynchronizationContext());

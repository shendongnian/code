    private Task DoStuff()
    {
        return Task.Factory.StartNew(() => Thread.Sleep(5000));
    }
    public void Execute(object parameter)
    {
       DoStuff().ContinueWith(result => Name = "OK", TaskScheduler.FromCurrentSynchronizationContext());
       //Same as above, probably should specify appropriate TaskOptions to run the continuation
       //only when the task was completed successfully.
    }

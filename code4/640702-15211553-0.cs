    private void Execute()
    {
        // Bound to a wait indicator in the UI
        Searching = true;
        Task.Factory.StartNew( () => { 
            // Do long running work... 
        }).ContinueWith(t =>
        {
            // You can do work here, including touching UI controls/collections/etc
            Searching = false;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

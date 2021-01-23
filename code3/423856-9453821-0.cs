    // must be executed in background
    foreach (Item item in Items)
    {
        EventWaitHandle Wait = new AutoResetEvent(false);
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            _events.Add(_newItem);
            Wait.Set();
        });
        // wait while item is added on UI
        Wait.WaitOne();
    }
    // here all items are added

    var h = SomeEvent;
    if (h != null)
    {
        await Task.Factory.StartNew(() => h(this, EventArgs.Empty),
            Task.Factory.CancellationToken,
            Task.Factory.CreationOptions,
            TaskScheduler.FromCurrentSynchronizationContext());
    }

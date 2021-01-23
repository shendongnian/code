    private void ProcessItems(IList<Item> items)
    {
        Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < items.Count; ++i)
            {
                // Code here runs on background thread.
                this.ProcessItem(items[i]);
                this.Dispatcher.Invoke(DispatcherPriority.Normal, () =>
                {
                    // Code here runs on UI thread.
                    this.UpdateStatus("Completed " + (i + 1) + " of " + items.Count);
                });
            }
        },
            TaskCreationOptions.LongRunning);
    }

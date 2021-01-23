    var queue = new BlockingCollection<Action>();
    
    int numWorkers = 5;
    
    for (int i = 0; i < numWorkers; i++)
    {
        Task.Factory.StartNew(() =>
        {
            foreach (var action in queue.GetConsumingEnumerable())
            {
                action();
            }
        }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }

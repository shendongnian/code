    var queue = new BlockingCollection<Action>();
    
    int numWorkers = 5;
    
    for (int i = 0; i < numWorkers; i++)
    {
        Thread t = new Thread(() =>
        {
            foreach (var action in queue.GetConsumingEnumerable())
            {
                action();
            }
        });
        t.Start();
    }

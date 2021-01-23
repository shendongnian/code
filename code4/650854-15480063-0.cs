    var queue = new BlockingCollection<Action>();
    
    //put work to do in the queue
    for (int i = 0; i < 10; i++)
        queue.Add(() => ProcessImage());
    queue.CompleteAdding();
    
    //create two workers
    for (int i = 0; i < 2; i++)
    {
        Task.Factory.StartNew(() =>
        {
            foreach (var action in queue.GetConsumingEnumerable())
                action();
        });
    }
    
    //to cancel the work, empty the queue
    Task.Delay(5000)
        .ContinueWith(t =>
        {
            queue.GetConsumingEnumerable().Count();
        });

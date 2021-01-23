    BlockingCollection<string> queue =
        new BlockingCollection<string>();
    // monitor thread.
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            Thread.Sleep(1000);
            queue.Add("event occured.");
        }
    });
         
    // main thread.
    while (true)
    {
        // blocks when no messages are in queue.
        string message = queue.Take();
                
        // kill process thread here.
    }

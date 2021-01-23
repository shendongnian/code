    BlockingCollection<YourJob> bc = new BlockingCollection<YourJob>();
    // populate the BlockingCollection (does not have to be in Task)
    Task t1 = Task.Factory.StartNew(() =>
    {
        bc.Add(new YourJob());
        bc.Add(new YourJob());
        bc.Add(new YourJob());
        bc.CompleteAdding();
    });
    // Spin up a Task to consume the BlockingCollection
    Task t2 = Task.Factory.StartNew(() =>
    {
        try
        {
            while (true)
            {
                YourJob job = bc.Take();
                job.Execute();
            }
        }
        catch (InvalidOperationException)
        {
            // IOE means that Take() was called on a completed (empty) collection
        }
    });
    Task.WaitAll(t1, t2);

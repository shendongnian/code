    public Task DoWork(IList<Action> actions)
    {
        List<Task> tasks = new List<Task>();
        int numWorkers = 10;
        int batchSize = (int)Math.Ceiling(actions.Count / (double)numWorkers);
        foreach (var batch in actions.Batch(actions.Count / 10))
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                foreach (var action in batch)
                {
                    action();
                }
            }));
        }
    
        return Task.WhenAll(tasks);
    }

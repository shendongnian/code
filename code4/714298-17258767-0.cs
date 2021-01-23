    public void ExecuteAllTasks()
    {
        var exceptions = new List<Exception>();
        IEnumerable<MyTask> tasks = GetQueuedTasks(); // get all tasks (or possibly pass them to the method) ...
        foreach (MyTask task in tasks)
        {
            try
            {
                // execute your tasks here ...
            }
            catch (Exception ex)
            {
                // collect all the exceptions
                exceptions.Add(ex);
            }            
        }
        // throw all the errors at once
        if (exceptions.Any())
            throw new AggregateException(_exceptions);
    }

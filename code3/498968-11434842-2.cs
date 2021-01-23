    public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
    {
        var allResults = new List<Bar>();
        // We are using all the default options on the TaskFactory
        // except when we are appending the results this has to be synchronized
        // as List<> is not multithreading safe (a more appropriate collection perhaps)
        var taskFactory = new TaskFactory<IEnumerable<Bar>>(
            TaskCreationOptions.None,
            TaskContinuationOptions.ExecuteSynchronously);
        // Kick off a task for every processor
        var syncRoot = new object();
        foreach (IProcessor t in processors)
        {
            IProcessor processor = t;
            // Execute the Provide
            // ContinueWith appending the result
            // Wait for a maximum of 5 seconds
            taskFactory
                .StartNew(() => processor.Provide(param))
                .ContinueWith(task =>
                {
                    lock (syncRoot)
                    {
                        allResults.AddRange(task.Result);
                    }
                })
                .Wait(5 * 1000);
        }
        // Execute the callback when all the results are in
        callback(allResults);
    }

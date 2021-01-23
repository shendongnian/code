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
        var tasks =
            new List<Task<IEnumerable<Bar>>>(processors.Count());
        tasks.AddRange(
            processors.Select(
                processor =>
                taskFactory.StartNew(() => processor.Provide(param))));
        if (Task.WaitAll(tasks.ToArray(), 5 * 1000))
        {
            foreach (Task<IEnumerable<Bar>> task in tasks)
            {
                allResults.AddRange(task.Result);
            }
            callback(allResults);
        }
    } 

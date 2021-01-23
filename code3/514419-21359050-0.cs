    ConcurrentDictionary<Task, string> runningTasks = new ConcurrentDictionary<Task, string>();
    Task task = Task.Factory.StartNew(() =>
        {
            // Do your stuff
        }).ContinueWith(processedTask => {
            var outString; // A string we don't care about
            runningTasks.TryRemove(processedTask, out outString);
        });
    runningTasks.TryAdd(task, "Hello I'm a task");
    // Add lots more tasks to runningTasks
    while (runningTasks.Count > 0)
    {
         Console.WriteLine("I'm still waiting...");
         Thread.Sleep(1000);
    }

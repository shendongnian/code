    Func<bool> DummyMethod = () =>{
        // When ready, send back complete!
        return true;
    };
    // Create list of tasks
    System.Threading.Tasks.Task<bool>[] tasks = new System.Threading.Tasks.Task<bool>[2];
    // First task
    var firstTask = System.Threading.Tasks.Task.Factory.StartNew(() => DummyMethod(), TaskCreationOptions.LongRunning);
    tasks[0] = firstTask;
    // Second task
    var secondTask = System.Threading.Tasks.Task.Factory.StartNew(() => DummyMethod(), TaskCreationOptions.LongRunning);
    tasks[1] = secondTask;
    // Launch all
    System.Threading.Tasks.Task.WaitAll(tasks);

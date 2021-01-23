    //add reference to the 'Task Scheduler 1.1 Type Library'
    using TaskScheduler;
    //...
    TaskSchedulerClass ts = new TaskSchedulerClass();
    ts.Connect(remotehost, user, domain, password);
    IRunningTaskCollection tasks = ts.GetRunningTasks(1);
    foreach (IRunningTask task in tasks)
    {
        Console.WriteLine(task.Name);
    }

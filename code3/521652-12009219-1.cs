    Task[] tasks = new Task[3];
    tasks[0] = Task.Factory.StartNew(() => Function1());
    tasks[1] = Task.Factory.StartNew(() => Function2());
    tasks[2] = Task.Factory.StartNew(() => Function3());
    Task.WaitAll(tasks);

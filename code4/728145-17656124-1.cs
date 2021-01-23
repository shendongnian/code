    static void RunTasks(BlockingCollection<ITask> tasks)
    {
        foreach (var task in tasks.GetConsumingEnumerable())
        {
            task.Execute();
            // this may not be as accurate as you would like
            Thread.Sleep(500);
        }
    }

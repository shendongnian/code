    static void RunTasks(BlockingCollection<ITask> tasks)
    {
        foreach (var task in tasks.GetConsumingEnumerable())
        {
            Task.Delay(500)
                .ContinueWith(() => task.Execute())
                .Wait();
        }
    }

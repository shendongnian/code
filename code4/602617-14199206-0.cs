    public static TaskAwaiter GetAwaiter(this Task[] tasks)
    {
        return tasks.First().GetAwaiter();
    }
    Task[] tasks = …;
    await tasks;

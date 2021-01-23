    public static TaskAwaiter GetAwaiter(this IEnumerable<Task> tasks)
    {
        return tasks.First().GetAwaiter();
    }
    IEnumerable<Task> tasks = …;
    await tasks;

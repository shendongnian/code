    private readonly Queue<Func<bool>> taskQueue = new Queue<Func<bool>>();
    public void EnqueueTask(Task task, object[] values)
    {
        taskQueue.Add(() => task(values));
    }

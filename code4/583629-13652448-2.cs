    public void EnsureStarted(Task task)
    {
        if (task.Status == TaskStatus.Created)
        {
            task.Start();
        }
    }

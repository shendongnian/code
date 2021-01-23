    foreach (var taskFunc in initialCoroutines)
    {
        coroutineTasks.Add(taskFunc(this));
    }
    while (actions.Count > 0)
    {
        Task failed = coroutineTasks.FirstOrDefault(t => t.IsFaulted);
        if (failed != null)
        {
            throw failed.Exception;
        }
        actions.Dequeue().Invoke();
    }

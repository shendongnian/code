    Task.Factory.StartNew(() =>
    {
        foreach (Action<object[]> action in taskQueue.GetConsumingEnumerable())
            action(paramQueue[i]);
    });

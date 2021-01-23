    private void DoTasksWhile(Func<bool> predicate, IEnumerable<Action> tasks)
    {
        foreach (var task in tasks)
        {
            if (!predicate())
                return;
            task();
        }
    }

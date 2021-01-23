    public static Task<IEnumerable<T>> WhenAll<T>(IEnumerable<Task<T>> tasks)
    {
        return Task.Factory.ContinueWhenAll(tasks.ToArray(),
            results => results.Select(t => t.Result));
    }

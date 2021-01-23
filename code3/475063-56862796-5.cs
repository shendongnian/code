    public static async Task<T[]> WhenAll<T>(IEnumerable<Task<T>> tasks,
        int degreeOfParallelism)
    {
        if (tasks is ICollection<Task<T>>) throw new ArgumentException(
            "The enumerable should not be materialized.", nameof(tasks));
        var enumeratorLock = new object();
        var results = new List<(int Index, T Result)>();
        var failed = false;
        using (var enumerator = tasks.GetEnumerator())
        {
            int index = 0;
            var workerTasks = Enumerable.Range(0, degreeOfParallelism)
            .Select(async _ =>
            {
                try
                {
                    while (true)
                    {
                        Task<T> task;
                        int localIndex;
                        lock (enumeratorLock)
                        {
                            if (failed || !enumerator.MoveNext()) break;
                            task = enumerator.Current;
                            localIndex = index++;
                        }
                        var result = await task.ConfigureAwait(false);
                        lock (results) results.Add((localIndex, result));
                    }
                }
                catch
                {
                    lock (enumeratorLock) failed = true;
                    throw;
                }
            }).ToArray();
            await Task.WhenAll(workerTasks).ConfigureAwait(false);
        }
        return results.OrderBy(e => e.Index).Select(e => e.Result).ToArray();
    }

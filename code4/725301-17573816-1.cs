    public static void AddPrintStatements2(IEnumerable<Task<string>> tasks)
    {
        Task continuation = Task.FromResult(true);
        foreach (var task in tasks)
        {
            continuation = continuation.ContinueWith(t =>
                task.ContinueWith(t2 => PrintResults(t2.Result)))
                .Unwrap();
        }
    }

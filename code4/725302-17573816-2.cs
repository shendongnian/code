    public static void AddPrintStatements(IEnumerable<Task<string>> tasks)
    {
        Task.WhenAll(tasks)
            .ContinueWith(t =>
            {
                foreach (var line in t.Result)
                    PrintResults(line);
            });
    }

    private static async Task MainAsync()
    {
        IWebSearcher webSearcher = new WebSearcher();
        // Start all SearchAndPrint operations concurrently.
        Task[] tasks = Enumerable.Range(0, 100)
            .Select(i => SearchAndPrintAsync(webSearcher, i))
            .ToArray();
        // Wait for them all to complete.
        await Task.WhenAll(tasks);
        Console.WriteLine("Done");
    }
    public static void Main()
    {
        MainAsync().Wait();
    }

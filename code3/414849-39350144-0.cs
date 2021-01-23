    private static int Main(string[] args)
    {
        var source = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = true;
            source.Cancel();
        };
        try
        {
            return MainAsync(args, source.Token).GetAwaiter().GetResult();
        }
        catch (OperationCanceledException)
        {
            return 1223; // Cancelled.
        }
    }
    private static async Task<int> MainAsync(string[] args, CancellationToken token)
    {
        // Your code...
        return 0; // Success.
    }

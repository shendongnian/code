    private static int Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = !cts.IsCancellationRequested;
            cts.Cancel();
        };
        try
        {
            return MainAsync(args, cts.Token).GetAwaiter().GetResult();
        }
        catch (OperationCanceledException)
        {
            return 1223; // Cancelled.
        }
    }
    private static async Task<int> MainAsync(
        string[] args, CancellationToken cancellationToken)
    {
        // Your code...
        return await Task.FromResult(0); // Success.
    }

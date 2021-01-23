    [Fact]
    public async Task AwaitFirst()
    {
        var servers = new[] { "server1", "server2", "server3", "server4" };
        var server = await servers
            .Select(s => Observable
                .FromAsync(ct => CallServer(s, ct))
                .Where(p => p)
                .Select(_ => s)
            )
            .Merge()
            .FirstAsync();
        output.WriteLine($"Got result from {server}");
    }
    private async Task<bool> CallServer(string server, CancellationToken ct)
    {
        try
        {
            if (server == "server1")
            {
                await Task.Delay(TimeSpan.FromSeconds(1), ct);
                output.WriteLine($"{server} finished");
                return false;
            }
            if (server == "server2")
            {
                await Task.Delay(TimeSpan.FromSeconds(2), ct);
                output.WriteLine($"{server} finished");
                return false;
            }
            if (server == "server3")
            {
                await Task.Delay(TimeSpan.FromSeconds(3), ct);
                output.WriteLine($"{server} finished");
                return true;
            }
            if (server == "server4")
            {
                await Task.Delay(TimeSpan.FromSeconds(4), ct);
                output.WriteLine($"{server} finished");
                return true;
            }
        }
        catch(OperationCanceledException)
        {
            output.WriteLine($"{server} Cancelled");
            throw;
        }
        throw new ArgumentOutOfRangeException(nameof(server));
    }

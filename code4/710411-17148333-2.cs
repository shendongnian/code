    static void Main(string[] args)
    {
        try
        {
            MainAsync().Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.ReadKey();
    }
    static async Task MainAsync()
    {
        ServicePointManager.DefaultConnectionLimit = int.MaxValue;
        var sw = new Stopwatch();
        var client = new HttpClient();
        var connections = Environment.ProcessorCount;
        var url = "http://localhost:35697/api/values/";
        await client.GetStringAsync(url); // warmup
        sw.Start();
        await Task.WhenAll(Enumerable.Range(0, connections).Select(i => client.GetStringAsync(url)));
        sw.Stop();
        Console.WriteLine("Synchronous time for " + connections + " connections: " + sw.Elapsed);
        connections = Environment.ProcessorCount + 1;
        await client.GetStringAsync(url); // warmup
        sw.Restart();
        await Task.WhenAll(Enumerable.Range(0, connections).Select(i => client.GetStringAsync(url)));
        sw.Stop();
        Console.WriteLine("Synchronous time for " + connections + " connections: " + sw.Elapsed);
        url += "13";
        connections = Environment.ProcessorCount;
        await client.GetStringAsync(url); // warmup
        sw.Restart();
        await Task.WhenAll(Enumerable.Range(0, connections).Select(i => client.GetStringAsync(url)));
        sw.Stop();
        Console.WriteLine("Asynchronous time for " + connections + " connections: " + sw.Elapsed);
        connections = Environment.ProcessorCount + 1;
        await client.GetStringAsync(url); // warmup
        sw.Restart();
        await Task.WhenAll(Enumerable.Range(0, connections).Select(i => client.GetStringAsync(url)));
        sw.Stop();
        Console.WriteLine("Asynchronous time for " + connections + " connections: " + sw.Elapsed);
    }

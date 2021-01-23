    [Test]
    public void Compose()
    {
        var server = new Server();
        server.Compose();
        Console.WriteLine("Plugins found: " + server.FASTAdapters.Count());
        Console.WriteLine();
        foreach (var adapter in server.FASTAdapters)
        {
            Console.WriteLine(adapter.GetType());
            Console.WriteLine(adapter.GetType().Assembly.FullName);
            Console.WriteLine(adapter.GetType().Assembly.CodeBase);
            Console.WriteLine();
        }
        Assert.Pass();
    }

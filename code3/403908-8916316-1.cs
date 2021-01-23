    if (!args.Any())
    {
        Console.Error.WriteLine("Usage: send.exe <executable>");
        Environment.Exit(-1);
    }
    
    using (var client = new TcpClient("localhost", 10101))
    using (var file = File.Open(args.First(), FileMode.Open, FileAccess.Read))
    {
        file.CopyTo(client.GetStream());
    }

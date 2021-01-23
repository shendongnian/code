    var factory = new ChannelFactory<ITestService>();
    try
    {
        factory.Open();
    }
    catch
    {
        Console.WriteLine(factory.State);
    }

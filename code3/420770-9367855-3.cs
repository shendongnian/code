    try
    {
        var factory = new ChannelFactory<MyServiceChannel>();
        var client = factory.CreateChannel();
        client.DoSomething();
        client.Close();
    }
    catch
    {
        if (client != null)
        {
             client.Abort();
        }
    }

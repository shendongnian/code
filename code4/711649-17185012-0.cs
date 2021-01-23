    ChannelFactory<IProcessor> factory = null;
    try
    {
        var netTcpBinding = new NetTcpBinding("netTcpBinding_BigPackets");
        factory = new ChannelFactory<IProcessor>(netTcpBinding);
        var processor = factory.CreateChannel(processorAddress);
        var result = processor.Process(request);
        return result;
    }
    catch (CommunicationException)
    {
        if (factory != null)
        {
            factory.Abort();
            factory = null;
        }
        throw;
    }
    finally
    {
        if (factory != null)
        {
            factory.Close();
        }
    }

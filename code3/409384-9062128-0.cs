    ChannelFactory<IMyService> channelFactory = null;
    try
    {
        channelFactory =
            new ChannelFactory<IMyService>();
        channelFactory.Open();
    
        // Do work...
    
        channelFactory.Close();
    }
    catch (CommunicationException)
    {
        if (channelFactory != null)
        {
            channelFactory.Abort();
        }
    }
    catch (TimeoutException)
    {
        if (channelFactory != null)
        {
            channelFactory.Abort();
        }
    }
    catch (Exception)
    {
        if (channelFactory != null)
        {
            channelFactory.Abort();
        }
        throw;
    }

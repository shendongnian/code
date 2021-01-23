    while (receiving)
    {
        try
        {
            data = client.Receive(ref endPoint);
            ...
        }
        catch (SocketException ex)
        {
            receiving = false;
        }
    }

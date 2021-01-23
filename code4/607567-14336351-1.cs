    while (receiving)
    {
        try
        {
            // block until data is present
            data = client.Receive(ref remoteEp);
            ...
        }
        catch (SocketException ex)
        {
            receiving = false;
        }
    }

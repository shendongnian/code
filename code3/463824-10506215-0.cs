    try
    {
        server.Start();
    }
    catch (SocketException exception)
    {
        Console.Write(exception.ErrorCode);
    }

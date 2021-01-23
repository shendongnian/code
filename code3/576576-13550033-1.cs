    string boundary = string.Format("--{0}--", Guid.NewGuid());
    byte[] boundaryBytes = Encoding.ASCII.GetBytes(boundary);
    //Every 15 seconds write a byte to the stream.
    for (int i = 0; i < 10; i++)
    {
        stream.WriteByte(0);
        Thread.Sleep(15000);
    }
    //Indicate where the end of the heartbeat bytes is.
    stream.Write(boundaryBytes, 0, boundaryBytes.Length);
    //Same code as before.
    try
    {
        stream.Write(responseBytes, 0, responseBytes.Length);
    }
    catch (SocketException ex)
    {
        Console.WriteLine("Socket exception in server: {0}", ex.Message);
    }

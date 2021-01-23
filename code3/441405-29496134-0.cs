    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
    if (socket.Available > 0)
    {
       int bytesRec = socket.Receive(bytes);
       Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));
    }

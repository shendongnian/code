    public void SendMessage(string message)
    {
        var data = Encoding.UTF8.GetBytes(message);
        if (data.Length > byte.MaxValue) throw new Exception("Data exceeds maximum size");
        var bufferList = new[]
        {
            new ArraySegment<byte>(new[] {(byte) data.Length}),
            new ArraySegment<byte>(data)
        };
        ClientSocket.Send(bufferList);
    }

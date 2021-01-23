    public static Task<int> SendTaskAsync(this Socket socket, IList<ArraySegment<byte>> buffers, SocketFlags flags)
    {
      return Task<int>.Factory.FromAsync(socket.BeginSend, socket.EndSend, buffers, flags, null);
    }
    public static Task WriteAsync(this Socket socket, byte[] buffer)
    {
      int bytesSent = 0;
      while (bytesSent != buffer.Length)
      {
        var data = new ArraySegment<byte>(buffer, bytesSent, buffer.Length - bytesSent);
        bytesSent += await socket.SendTaskAsync(new [] { data }, SocketFlags.None);
      }
    }

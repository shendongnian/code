    public static Task<int> SendTaskAsync(this Socket socket, byte[] buffer, int offset, int size, SocketFlags flags)
    {
      return Task<int>.Factory.FromAsync(socket.BeginSend, socket.EndSend, buffer, offset, size, flags, null);
    }
    public static Task WriteAsync(this Socket socket, byte[] buffer)
    {
      int bytesSent = 0;
      while (bytesSent != buffer.Length)
      {
        bytesSent += await socket.SendTaskAsync(data, bytesSent, buffer.Length - bytesSent, SocketFlags.None);
      }
    }

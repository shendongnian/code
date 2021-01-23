    public static Task<int> ReceiveAsyncTask(this Socket socket,
        byte[] buffer, int offset, int size)
    {
      return AsyncFactory<int>.FromApm(socket.BeginReceive, socket.EndReceive,
          buffer, offset, size, SocketFlags.None);
    }

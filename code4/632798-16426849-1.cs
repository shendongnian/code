    public static string Receive(int port) {
      string data = null;
      listener = new TcpListener(IPAddress.Any, port);
      listener.Start();
      using (var client = listener.AcceptTcpClient()) { // waits until data is avaiable
        int MAX = client.ReceiveBufferSize;
        var stream = client.GetStream();
        Byte[] buffer = new Byte[MAX];
        int len = stream.Read(buffer, 0, MAX);
        if (0 < len) {
          data = Encoding.UTF8.GetString(buffer, 0, len);
        }
        stream.Close();
        client.Close();
      }
      return data;
    }

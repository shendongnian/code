    public static void Send(string message, string host, int port) {
      if (!String.IsNullOrEmpty(message)) {
        if (port < 80) {
          port = DEF_PORT;
        }
        Byte[] data = Encoding.ASCII.GetBytes(message);
        using (var client = new TcpClient(host, port)) {
          var stream = client.GetStream();
          stream.Write(data, 0, data.Length);
          stream.Close();
          client.Close();
        }
      }
    }

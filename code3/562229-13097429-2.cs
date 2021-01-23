    // inserting a sleep inside the loop will make everything work perfectly
    string SendCmd(string cmd, string ip, int port)
    {
      var client = new TcpClient(ip, port);
      var data = Encoding.GetEncoding(1252).GetBytes(cmd);
      var stm = client.GetStream();
      stm.Write(data, 0, data.Length);
      byte[] resp = new byte[2048];
      var memStream = new MemoryStream();
      NetworkStream networkStream = client.GetStream();
      // Set a 250 millisecond timeout for reading.
      networkStream.ReadTimeout = 250;
      int bytesread = stm.Read(resp, 0, resp.Length);
      while (bytesread > 0)
      {
          memStream.Write(resp, 0, bytesread);
          bytesread = stm.Read(resp, 0, resp.Length);
      }
      return Encoding.GetEncoding(1252).GetString(memStream.ToArray());
    }

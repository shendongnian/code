    string SendCmd(string cmd, string ip, int port)
    {
      var client = new TcpClient(ip, port);
      var data = Encoding.GetEncoding(1252).GetBytes(cmd);
      var stm = client.GetStream();
      // Set a 250 millisecond timeout for reading (instead of Infinite the default)
      stm.ReadTimeout = 250;
      stm.Write(data, 0, data.Length);
      byte[] resp = new byte[2048];
      var memStream = new MemoryStream();
      int bytesread = stm.Read(resp, 0, resp.Length);
      while (bytesread > 0)
      {
          memStream.Write(resp, 0, bytesread);
          bytesread = stm.Read(resp, 0, resp.Length);
      }
      return Encoding.GetEncoding(1252).GetString(memStream.ToArray());
    }

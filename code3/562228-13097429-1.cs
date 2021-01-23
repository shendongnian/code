    // inserting a sleep inside the loop will make everything work perfectly
    string SendCmd(string cmd, string ip, int port)
    {
      var client = new TcpClient(ip, port);
      var data = Encoding.GetEncoding(1252).GetBytes(cmd);
      var stm = client.GetStream();
      stm.Write(data, 0, data.Length);
      byte[] resp = new byte[2048];
      var memStream = new MemoryStream();
      int byteslefttoread = 2048;
      int bytesread = stm.Read(resp, 0, byteslefttoread);
      while (byteslefttoread > 0)
      {
          memStream.Write(resp, 0, bytesread);
          if (stm.DataAvailable)
          {
              bytesread = stm.Read(resp, 0, stm.Length);
              bytesleftoread -= bytesread;
          }
          else
              Thread.Sleep(20);
      }
      return Encoding.GetEncoding(1252).GetString(memStream.ToArray());
    }

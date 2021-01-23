    private int sendUsingTcp(string location) {
      string result = string.Empty;
      try {
        using (var fs = new FileStream(location, FileMode.Open, FileAccess.Read)) {
          using (var client = new TcpClient(GetHostIP, CpAppDatabase.ServerPortNumber)) {
            byte[] riteBuf = new byte[client.SendBufferSize];
            byte[] readBuf = new byte[client.ReceiveBufferSize];
            using (var ns = client.GetStream()) {
              if (ns.CanRead && ns.CanWrite) {
                int len;
                string AOK = string.Empty;
                do {
                  len = fs.Read(riteBuf, 0, riteBuf.Length);
                  ns.Write(riteBuf, 0, len);
                  int nsRsvp = ns.Read(readBuf, 0, readBuf.Length);
                  AOK = Encoding.ASCII.GetString(readBuf, 0, nsRsvp);
                } while ((len == riteBuf.Length) && (-1 < AOK.IndexOf("AOK")));
                result = AOK;
                return 1;
              }
              return 0;
            }
          }
        }
      } catch (Exception err) {
        MessageBox.Show(err.Message, "Message Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand, 0);
        return -1;
      }
    }

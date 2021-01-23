    using (var ns = client.GetStream()) {
      if (ns.CanRead && ns.CanWrite) {
        int len;
        byte[] AOK = Encoding.ASCII.GetBytes("AOK");
        using (var fs = new FileStream(location, FileMode.Create, FileAccess.Write)) {
          do {
            len = ns.Read(buf, 0, client.ReceiveBufferSize);
            fs.Write(buf, 0, len);
            ns.Write(AOK, 0, AOK.Length);
          } while ((0 < len) && ns.DataAvailable);
        }
        byte[] okBuf = Encoding.ASCII.GetBytes("Message Received on Server");
        ns.Write(okBuf, 0, okBuf.Length);
      }
    }

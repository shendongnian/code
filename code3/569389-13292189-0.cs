    Socket sock;
    // Snip init and connect
    sock.Send(ToBinary("Hello\nWorld"));
    sock.Send(ToBinary("Foo\nBar\nBaz"));
    byte[] ToBinary(string s) {
      var ms = new MemoryStream();
      var bw = new BinaryWriter(ms);
      bw.Write(s);
      bw.Flush();
      ms.Flush();
      return ms.ToArray();
    }

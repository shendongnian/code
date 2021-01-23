    Socket sock;
    MemoryStream ms = new MemoryStream();
    Queue<string> strings = new Queue<string>();
    // Snip init and receive connection
    sock.BeginReceive(buffer, 0, MaxSize, SocketFlags.None, new AsyncCallback(OnReceived), null);
    void OnReceived(IAsyncResult result) {
      // Snip sanity stuff
      int bytesReceived = sock.EndReceive(result);
      ms.Write(buffer, 0, bytesReceived);
      ms.Flush();
      long endPos = ms.Position;
      ms.Seek(0, SeekOrigin.Begin);
      long readPos = ms.Position;
      var bw = new BinaryReader(ms);
      for (;;) {
        try {
          string currentString = bw.ReadString();
          strings.Enqueue(currentString);
          readPos = stream.Position;
        }
        catch (EndOfStreamException) {
          long unusedBytes = endPos - readPos;
          var remaining = new MemoryStream();
          remaining.Write(stream.GetBuffer(), (int) readPos, (int) unusedBytes);
          ms = remaining;
          break;
        }
      }
      sock.BeginReceive(buffer, 0, MaxSize, SocketFlags.None, new AsyncCallback(OnReceived), null);
    }

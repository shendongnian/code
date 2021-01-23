    public void Listen() {
      listener.Start();
      while (!abortListener) {
        try {
          using (var client = listener.AcceptTcpClient()) {
            int MAX = client.ReceiveBufferSize;
            var now = DateTime.Now;
            using (var stream = client.GetStream()) {
              Byte[] buffer = new Byte[MAX];
              int len = stream.Read(buffer, 0, MAX);
              if (0 < len) {
                string data = Encoding.UTF8.GetString(buffer, 0, len);
                MethodInvoker method = delegate { NetworkResponder(this, new WmTcpEventArgs(data)); };
                abortListener = ((form1 == null) || form1.IsDisposed);
                if (!abortListener) {
                  form1.Invoke(method);
                }
              }
            }
          }
        } catch (Exception err) {
          Debug.WriteLine(err.Message);
        } finally {
          listener.Stop();
        }
      }
    }

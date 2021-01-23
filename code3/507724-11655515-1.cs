    private void Worker_TcpListener(object sender, DoWorkEventArgs e) {
      BackgroundWorker worker = (BackgroundWorker)sender;
      do {
        string eMsg = null;
        int port = 8000;
        try {
          _listener = new TcpListener(IPAddress.Any, port);
          _listener.Start();
          TcpClient client = _listener.AcceptTcpClient(); // waits until data is avaiable
          int MAX = client.ReceiveBufferSize;
          NetworkStream stream = client.GetStream();
          Byte[] buffer = new Byte[MAX];
          int len = stream.Read(buffer, 0, MAX);
          if (0 < len) {
            string data = Encoding.UTF8.GetString(buffer);
            worker.ReportProgress(len, data.Substring(0, len));
          }
          stream.Close();
          client.Close();
        } catch (Exception err) {
          // Log your error
        }
        if (!String.IsNullOrEmpty(eMsg)) {
          worker.ReportProgress(0, eMsg);
        }
      } while (!worker.CancellationPending);
    }

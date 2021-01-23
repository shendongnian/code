    private void Send(string value) {
      byte[] data = Encoding.ASCII.GetBytes(value);
      try {
        using (TcpClient client = new TcpClient(txtIPAddress.Text, 8000)) {
          NetworkStream stream = client.GetStream();
          stream.Write(data, 0, data.Length);
        }
      } catch (Exception err) {
        // Log the error
      }
    }

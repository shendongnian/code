    public void listener()
        {
      TcpListener tcpListener = new TcpListener(IPAddress.Any, 30000);
      tcpListener.Start();
      TcpClient tcpClient = tcpListener.AcceptTcpClient();
      NetworkStream clientStream = tcpClient.GetStream();
      byte[] message = new byte[4096];
      int bytesRead;
      while (true)
      {
        bytesRead = 0;
        try
        {
          //blocks until a client sends a message
          bytesRead = clientStream.Read(message, 0, 4096);
        }
        catch
        {
          //a socket error has occured
          break;
        }
        if (bytesRead == 0)
        {
          //the client has disconnected from the server
          break;
        }
        //message has successfully been received
        ASCIIEncoding encoder = new ASCIIEncoding();
        Console.Write(encoder.GetString(message, 0, bytesRead));
      }
      tcpClient.Close();
    }

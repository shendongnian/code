    public static  void sender()
    {
      TcpClient client = new TcpClient();
      IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("192.168.2.236"), 30000);
      client.Connect(serverEndPoint);
      NetworkStream clientStream = client.GetStream();
      ASCIIEncoding encoder = new ASCIIEncoding();
      byte[] buffer = encoder.GetBytes("Hello Server!");
      clientStream.Write(buffer, 0, buffer.Length);
      clientStream.Flush();
    }
    Connection accepted from 192.168.2.236:22811
    Recieved...
    Hello Server!

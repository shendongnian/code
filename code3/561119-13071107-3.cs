    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
    byte[] lengthBytes = new byte[4];
    socket.Receive(lengthBytes);
    int length = BitConverter.GetInt32(lengthBytes);
    byte[] messageBytes = new byte[length];
    socket.Receive(messageBytes);
    string message = Encoding.UTF8.GetString(messageBytes);
    Console.WriteLine(message);

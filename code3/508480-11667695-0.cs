    IPEndPoint host = new IPEndPoint(IPAddress.Parse("192.168.2.222"), 3306);
    
    Socket s = new Socket(AddressFamily.InterNetwork,
    s.ReceiveTimeout = 100;
    s.SendTimeout = 100;
    SocketType.Stream, ProtocolType.Tcp);
    s.Connect(host);
    if (s.Connected) { 
          MessageBox.Show("Ping Ok!!!"); 
    } else {
           MessageBox.Show("Ping not Ok !!!");
    }

    try
    {
        // Establish the remote endpoint for the socket.
        // This example uses port 11000 on the local computer.
        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName())
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint remoteEP = new IPEndPoint(ipAddress,15000);
        string notification = "new_update";
        byte[] sendBuffer = Encoding.ASCII.GetBytes(notification);
        sock.SendTo(sendBuffer, remoteEP );
        sock.Close();  
    }
    catch() {}

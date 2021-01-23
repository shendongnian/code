    private void RecieveChallenge()
    {
        UdpClient client = new UdpClient(26000);
        IPEndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
    
        Byte[] receivedBytes = client.Receive(ref remoteIp);
        if (receivedBytes == null || receivedBytes.Length == 0)
            return;
        string ipAddress = Encoding.ASCII.GetString(receivedBytes);
    }

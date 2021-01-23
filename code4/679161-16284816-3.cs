    // Method takes a TcpClient Object and Encoder, returning a response to the CLIENTIP request
    public byte[] IPKLIENTI(TcpClient tcpClient, ASCIIEncoding encoder)
    {
        string answer = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
        byte[] buffer = encoder.GetBytes(answer);
        return buffer;
    }

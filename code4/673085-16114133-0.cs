    Form1()
    {
        UdpClient client = new UdpClient(987);
        client.BeginReceive(UDPClient_Callback, client);
    }
  
    void UDPClient_Callback(IAsyncResult result)
    {
    }

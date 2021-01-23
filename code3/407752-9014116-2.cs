    private void ScanPort(int port)
    {
        var client = new TcpClient();
        try {
            client.BeginConnect(IPAddress.Parse("74.125.226.84"), port, new AsyncCallback(CallBack), client);
        } catch (SocketException) {
            ...
            client.Close();
        }
    }

    private void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream stm = clientList[n].GetStream();
        msg = new TheMessage();

    TcpListener tcpListener = new TcpListener(IPAddress.Any, 90);
    bool isListening;
    public void BeginAccept()
    {
        while (isListening)
        {
            TcpClient tcpClient;
            try { tcpClient = tcpListener.AcceptTcpClient(); }
            catch { /* Swallowing is bad */ }
            // TODO: Add your brand new tcpClient to some sort of collection, may be.
        }
    }

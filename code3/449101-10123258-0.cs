    TcpListener tcpListener = new TcpListener(IPAddress.Any, 90);
    public void BeginAccept()
    {
        try { tcpListener.BeginAcceptTcpClient(AcceptClient, null); }
        catch { /* Swallowing is bad */ }
    }
    private void AcceptClient(IAsyncResult ar)
    {
        TcpClient tcpClient;
        try { tcpClient = tcpListener.EndAcceptTcpClient(ar); }
        catch { /* Swallowing is bad */ }
        finally { BeginAccept(); }
        // TODO: Add your brand new tcpClient to some sort of collection, may be.
    }

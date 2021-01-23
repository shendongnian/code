    TcpListener listener = null;
    ConnectionManager()
    {
        listener = new TcpListener(port);
        listener.BeginAcceptSocket(new AsyncCallback(acceptConnection), listener);
    }
    public void acceptConnection(IAsyncResult ar)
    {
        // Create async receive data code..
        // Get ready for a new connection
        listener.BeginAcceptSocket(new AsyncCallback(acceptConnection), listener);
    }

    public void OnConnectRequest(IAsyncResult ar)
    {
        Socket listener = (Socket)ar.AsyncState;
        Socket accepted = listener.EndAccept(ar);
        listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener);
        NewConnection(accepted);
    }

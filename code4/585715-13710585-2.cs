    private ManualResetEvent _connectionAccepted;
    
    public void WaitForData()
    {
        while (true)
        {
            _connectionAccepted.Reset();
            socket.BeginAccept(new AsyncCallback(AcceptCallback), state);
            _connectionAccepted.WaitOne();
        }
    }
    private void Acceptcallback(IAsyncResult ar)
    {
         _connectionAccepted.Set();
         Socket socket = (Socket)ar.AsyncState;
         Socket handler = socket.EndAccept(ar);
         State state = new State();
         state.Client = handler;
         handler.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, new AsyncCallback(ServerReadCallback), handler);
    }

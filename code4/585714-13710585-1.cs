    private ManualResetEvent _connectionAccepted;
    
    public void WaitForData()
    {
        State state = new State();
        state.Client = socket;
        while (true)
        {
            _connectionAccepted.Reset();
            state.Client.BeginAccept(new AsyncCallback(AcceptCallback), state);
            _connectionAccepted.WaitOne();
        }
    }
    private void Acceptcallback(IAsyncResult ar)
    {
         _connectionAccepted.Set();
         State state = (State)ar.AsyncState;
         Socket handler = state.Client.EndAccept(ar);
         handler.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, new AsyncCallback(ServerReadCallback), state);
    }

    listener.Start();
    listener.BeginAcceptSocket(OnAccept, null);
    
    private void OnAccept(IAsyncResult ar)
    {
       var socket = listener.EndAcceptSocket(ar);
       listener.BeginAcceptSocket(OnAccept, null);
       // ... process this socket
    }

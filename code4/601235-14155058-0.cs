    IDisposable myLock;
    
    myLock = sharedLock.ObtainLock(delegate() {
         socket = new Socket();
         socket.BeginConnect(hostname, connectcallback);
    });
    
    void connectcallback(IAsyncResult result) {
        socket.EndConnect(result);
        isConnected = true;
        myLock.Dispose();
    }

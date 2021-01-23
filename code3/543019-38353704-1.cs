    if (signal)
    {
        allDone.Reset();
        // Start an asynchronous socket to listen for connections.
        string s = string.Format("Server Socket: Waiting for a connection at Port:{0}", listenPort);
        DisplayMsg(s);
        listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
    }
                
    // Wait until a connection is made before continuing.
    signal = allDone.WaitOne(100);

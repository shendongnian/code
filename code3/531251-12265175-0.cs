    while (!mb_RTSPWorkerAbbort)
    {
        // Call TransportWD
        Thread.Sleep(100*mi_ConnectionTimeOut);
        if (ConnectionSollState == TypeConnectionState.Closed)
        {
            CloseIfConnected();
        }
        if (ConnectionSollState == TypeConnectionState.Connected)
        {
            if (ConnectionState == TypeConnectionState.Connected)
            {
                KeepAlive();
                ProcessStreams(); // <--bad example name - rename to what it's actually doing.
            }
            else
            {
                Reconnect();
            }
        }
    }

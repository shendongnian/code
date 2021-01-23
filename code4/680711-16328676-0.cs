    //setup a timer variable
    TCPClient connectionOpening;
    _connecting = true;
    _connected = false;
    connectionOpening = tcpClient;
    timer.change(5000, Infinite)
    tcpClient.BeginConnect(ClientConnectCallback, tcpClient)
    void ClientConnectCallback(iasyncresult ar)
    { 
        _timer.change(infinite, infinite);
        TCPClient tcp = (TCPClient)ar.AsyncState;
        try
        {
            //if we have timed out because our time will abort the connect
            tcp.EndConnect(ar);
            _connected = true;
            _connecting = false;
            //we are now connected... do the rest you want to do.
            //get the stream and BeginRead etc.
        }
        catch (Exception ex) // use the proper exceptions IOException , socketException etc
        {
            if (!_connecting)
            {
                //We terminated the connection because our timer ticked.
            }
            else
            {
                //some other problem that we weren't expecting
            }
        }
    void TimerTick(object state)
    {
        _connecting = false;
        _connected = false;
        connectionOpening.Close();
    }

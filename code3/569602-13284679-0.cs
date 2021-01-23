    static bool _isSending;
    static void doSend(string ip, int port)
    {
        _isSending = true;
        while (_isSending)
        {
            _sockMain = new UdpClient(ip, port);
            // ...
            _sockMain.Send(arr_bData, arr_bData.Length);
        }
    }
    
    static void Stop()
    {
        // set flag for exiting loop here
        _isSending = false;    
    }

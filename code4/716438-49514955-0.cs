	Task.Run(() => ReceiveLoop());
    void ReceiveLoop()
    {
        var receivedDataEvent = new AutoResetEvent(false);
        myFtdiDevice.SetEventNotification(FT_EVENTS.FT_EVENT_RXCHAR, receivedDataEvent);
        var cancellation = new CancellationTokenSource();  // should be declared in a broader scope
        while (!_cancellation.IsCancellationRequested)
        {
            receivedDataEvent.WaitOne();
            ReadAvailable();
        }
    }
    void ReadAvailable()
    {
        uint rxBytesAvailable = 0;
        myFtdiDevice.GetRxBytesAvailable(ref rxBytesAvailable);
        if (rxBytesAvailable < 1)
            return;
        byte[] bytes = new byte[rxBytesAvailable];
        uint numBytesRead = 0;
        myFtdiDevice.Read(bytes, rxBytesAvailable, ref numBytesRead);
        if (rxBytesAvailable != numBytesRead)
            logger.Warn("something happened")
        DoSomething(bytes);
    }

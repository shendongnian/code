    void OnDataReceived(IAsyncResult asyn)
    {
        var bytesRead = inboundSocket.EndReceive(asyn);
        if (bytesRead == 0) return; // Socket is closed
        // Process the data here
        WireUpCallbackForAsynchReceive();  // listen again for next inbound message
    } 

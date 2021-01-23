    try
    {
        if (!sender.Connected)
           Reconnect();
        int bytesRec = sender.Receive(readBuffer);    
        if (bytesRec == 0)
        {
            //warning 0 bytes received and some logging
            // Reconnect code here or function calling to reconnect
            Reconnect();
        }
        return Encoding.ASCII.GetString(readBuffer, 0, bytesRec);
    }
    catch (SocketException se)
    {
       //print se.ErrorCode
       throw;
    }

    try
    {
        using (DataReader reader = e.GetDataReader())
        {
            reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            string rawMessage = reader.ReadString(reader.UnconsumedBufferLength);
            // Do something with the message...
        }
    }
    catch (Exception ex)
    {
        var errorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.HResult);
        if (errorStatus == WebErrorStatus.ConnectionAborted)
        {
            // Handle the connection-abort...
        }
    }

    Socket socket; //Make a good socket before calling the rest of the code.
    int size = sizeof(UInt32);
    UInt32 on = 1;
    UInt32 keepAliveInterval = 10000; //Send a packet once every 10 seconds.
    UInt32 retryInterval = 1000; //If no response, resend every second.
    byte[] inArray = new byte[size * 3];
    Array.Copy(BitConverter.GetBytes(on), 0, inArray, 0, size);
    Array.Copy(BitConverter.GetBytes(keepAliveInterval), 0, inArray, size, size);
    Array.Copy(BitConverter.GetBytes(retryInterval), 0, inArray, size * 2, size);
    socket.IOControl(IOControlCode.KeepAliveValues, inArray, null);

    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    IAsyncResult result = socket.BeginConnect("192.168.1.180", 25, null, null);
    // Two second timeout
    bool success = result.AsyncWaitHandle.WaitOne(2000, true);
    if (!success) {
        socket.Close();
        throw new ApplicationException("Failed to connect server.");
    }

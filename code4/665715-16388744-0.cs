    DatagramSocket socket = new DatagramSocket();
    socket.MessageReceived += socket_MessageReceived;
    await socket.ConnectAsync(new HostName("time.windows.com"), "123");
    
    using (DataWriter writer = new DataWriter(socket.OutputStream))
    {
        byte[] container = new byte[48];
        container[0] = 0x1B;
    
        writer.WriteBytes(container);
        await writer.StoreAsync();
    }

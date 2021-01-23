    private StreamSocketListener listener;
    private async void Test()
    {
        listener = new StreamSocketListener();
        listener.ConnectionReceived += OnConnection;
        await listener.BindServiceNameAsync(port.ToString());
    }
    private async void OnConnection(StreamSocketListener sender,
        StreamSocketListenerConnectionReceivedEventArgs args)
    {
        // Streams for reading a writing.
        DataReader reader = new DataReader(listener.InputStream);
        DataWriter writer = new DataWriter(socket.OutputStream);
        writer.WriteString("Hello");
        await writer.StoreAsync();
    }

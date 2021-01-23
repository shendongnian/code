    // Create a class to hold details related to a client connection
    public class ClientConnection
    {
        public ClientConnection(NetworkStream networkStream, byte[] data)
        {
            NetworkStream = networkStream;
            Data = data;
        }
        public NetworkStream NetworkStream { get; private set; }
        public byte[] Data { get; private set; }
    }
    public void Listen()
    {
        myTcpListener.Start();
    
        while (true)
        {
            //blocks until a client has connected to the server
            myTcpClient = myTcpListener.AcceptTcpClient();
    
            var client = new ClientConnection(myTcpClient.GetStream(), new byte[myTcpClient.ReceiveBufferSize]);
            // Capture the specific client and pass it to the receive handler
            client.NetworkStream.BeginRead(client.Data, 0, client.Data.Length, r => receiveMessageHandler(r, client), null);
        }
    }
    
    public void receiveMessageHandler(IAsyncResult asyncResult, ClientConnection client)
    {
        var byteReadCount = client.NetworkStream.EndRead(asyncResult);
        if (byteReadCount < MIN_REQUEST_STRING_SIZE)
        {
            //Could not read form client.
            //Erro - Como tratar? Close()
        }
        else
        {
            if (socketReadCompleteEvent != null)
            {
                socketReadCompleteEvent(this, eventArguments);
            }
        }
    }

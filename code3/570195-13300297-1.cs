    int Port = 7777; // or whatever port you want to listen on
    IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);
    listenSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
    listenSocket.Bind(ipLocal);
    // create the call back for any client connections...
            listenSocket.BeginAccept(new AsyncCallback(OnClientConnection), null);
    private void OnClientConnection(IAsyncResult asyn)
        {
            if (socketClosed)
            {
                return;
            }
            try
            {
                Socket clientSocket = listenSocket.EndAccept(asyn);
                ConnectedClient connectedClient = new ConnectedClient(clientSocket, this);
                connectedClient.MessageReceived += OnMessageReceived;
                connectedClient.Disconnected += OnDisconnection;
                connectedClient.MessageSent += OnMessageSent;
                connectedClient.StartListening();
                // create the call back for any client connections...
                listenSocket.BeginAccept(new AsyncCallback(OnClientConnection), null);
            }
            catch (ObjectDisposedException excpt)
            {
                // Deal with this, your code goes here
            }
            catch (Exception excpt)
            {
                // Deal with this, your code goes here
            }
        }

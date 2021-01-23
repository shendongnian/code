    private void OnClientConnection(IAsyncResult asyn)
        {
            if (socketClosed)
            {
                return;
            }
            try
            {
                Socket clientSocket = listenSocket.EndAccept(asyn);
                ConnectedClient connectedClient = new ConnectedClient(clientSocket, this, _ServerTerminalReceiveMode);
                //connectedClient.MessageReceived += OnMessageReceived;
                connectedClient.Disconnected += OnDisconnection;
                connectedClient.dbMessageReceived += OndbMessageReceived;
                connectedClient.ccSocketFaulted += ccSocketFaulted;
                connectedClient.StartListening();
                long key = clientSocket.Handle.ToInt64();
                if (DictConnectedClients.ContainsKey(connectedClient.SocketHandleInt64))
                {
                    // Already here - use your own error reporting..
                }
                lock (DictConnectedClients)
                {
                    DictConnectedClients[key] = connectedClient;
                }
                // create the call back for any client connections...
                listenSocket.BeginAccept(new AsyncCallback(OnClientConnection), null);
            }
            catch (ObjectDisposedException excpt)
            {
                // Your own code here..
            }
            catch (Exception excpt)
            {
                // Your own code here...
            }
        }

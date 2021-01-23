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
                connectedClient.StartListening();

    // Read data from the client
    private void ReadCallback(IAsyncResult ar)
    {
        StateObject state = (StateObject)ar.AsyncState;
        Socket socket = state.workSocket;
        try
        {
            if (socket.Connected)
            {
                // Read the socket
                int bytesRead = socket.EndReceive(ar);
                
                // Deserialize objects
                foreach (MessageBase msg in MessageBase.Receive(socket, bytesRead, state))
                {
                    // Add objects to the message queue
                    lock (this.messageQueue)
                        messageQueue.Enqueue(msg);
                }
                // Notify any event handlers
                if (DataRecieved != null)
                    DataRecieved(socket, bytesRead);
                // Asynchronously read more client data
                socket.BeginReceive(state.Buffer, state.readOffset, state.BufferSize - state.readOffset, 0,
                    ReadCallback, state);
            }
            else
            {
                HandleClientDisconnect(socket);
            }
        }
        catch (SocketException)
        {
            HandleClientDisconnect(socket);
        }
    }

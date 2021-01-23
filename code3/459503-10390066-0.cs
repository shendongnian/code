    // Server socket
    class ControllerSocket : Socket, IDisposable
    {
        // MessageQueue queues messages to be processed by the controller
        public Queue<MessageBase> messageQueue = null;
    
        // This is a list of all attached clients
        public List<Socket> clients = new List<Socket>();
    
        #region Events
        // Event definitions handled in the controller
        public delegate void SocketConnectedHandler(Socket socket);
        public event SocketConnectedHandler SocketConnected;
    
        public delegate void DataRecievedHandler(Socket socket, int bytesRead);
        public event DataRecievedHandler DataRecieved;
    
        public delegate void DataSentHandler(Socket socket, int length);
        public event DataSentHandler DataSent;
    
        public delegate void SocketDisconnectedHandler();
        public event SocketDisconnectedHandler SocketDisconnected;
        #endregion
    
        #region Constructor
        public ControllerSocket(int port)
            : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            // Create the message queue
            this.messageQueue = new Queue<MessageBase>();
    
            // Acquire the host address and port, then bind the server socket
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            this.Bind(localEndPoint);
        }
        #endregion
    
        // Starts accepting client connections
        public void StartListening()
        {
            this.Listen(100);
            this.BeginAccept(AcceptCallback, this);
        }
    
        // Connects to a client
        private void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket socket = listener.EndAccept(ar);
    
            try
            {
                // Add the connected client to the list
                clients.Add(socket);
    
                // Notify any event handlers
                if (SocketConnected != null)
                    SocketConnected(socket);
    
                // Create an initial state object to hold buffer and socket details
                StateObject state = new StateObject();
                state.workSocket = socket;
                state.BufferSize = 8192;
    
                // Begin asynchronous read
                socket.BeginReceive(state.Buffer, 0, state.BufferSize, 0,
                    ReadCallback, state);
            }
            catch (SocketException)
            {
                HandleClientDisconnect(socket);
            }
            finally
            {
                // Listen for more client connections
                StartListening();
            }
        }
    
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
    
        // Send data to a specific client
        public void Send(Socket socket, MessageBase msg)
        {
            try
            {
                // Serialize the message
                byte[] bytes = msg.Serialize();
    
                if (socket.Connected)
                {
                    // Send the message
                    socket.BeginSend(bytes, 0, bytes.Length, 0, SendCallback, socket);
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
    
        // Broadcast data to all clients
        public void Broadcast(MessageBase msg)
        {
            try
            {
                // Serialize the message
                byte[] bytes = msg.Serialize();
    
                // Process all clients
                foreach (Socket client in clients)
                {
                    try
                    {
                        // Send the message
                        if (client.Connected)
                        {
                            client.BeginSend(bytes, 0, bytes.Length, 0, SendCallback, client);
                        }
                        else
                        {
                            HandleClientDisconnect(client);
                        }
                    }
                    catch (SocketException)
                    {
                        HandleClientDisconnect(client);
                    }
                }
            }
            catch (Exception e)
            {
                // Serialization error
                Console.WriteLine(e.ToString());
            }
        }
    
        // Data sent to a client socket
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
    
                if (socket.Connected)
                {
                    // Complete sending the data
                    int bytesSent = socket.EndSend(ar);
    
                    // Notify any attached handlers
                    if (DataSent != null)
                        DataSent(socket, bytesSent);
                }
                else
                {
                    HandleClientDisconnect(socket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    
        private void HandleClientDisconnect(Socket client)
        {
            // Client socket may have shutdown unexpectedly
            if (client.Connected)
                client.Shutdown(SocketShutdown.Both);
    
            // Close the socket and remove it from the list
            client.Close();
            clients.Remove(client);
    
            // Notify any event handlers
            if (SocketDisconnected != null)
                SocketDisconnected();
        }
    
        // Close all client connections
        public void Dispose()
        {
            foreach (Socket client in clients)
            {
                if (client.Connected)
                    client.Shutdown(SocketShutdown.Receive);
    
                client.Close();
            }
        }
    }

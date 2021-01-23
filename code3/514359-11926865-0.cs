    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public class SocketConnection
    {
        /// <summary>
        /// Event handler shot when message is received
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;
        /// <summary>
        /// Socket used for connection to the server, sending and receiving data
        /// </summary>
        Socket socket;
        /// <summary>
        /// Default buffer size that should be used with the same value in both server and client
        /// </summary>
        int bufferSize = 128;
        /// <summary>
        /// Buffer used to store bytes received
        /// </summary>
        byte[] buffer;
        /// <summary>
        /// Bytes received in current receiving operation
        /// </summary>
        int bytesReceived;
        public SocketConnection(string host = "localhost", int port = 4502)
        {
            // Initializing buffer for receiving data
            buffer = new byte[bufferSize];
            // Initializing socket to connect to the server with default parameters
            // *** If you need IPv6, set the AddressFamily.InterNetworkV6 ***
            // *** Silverlight supports only Stream or Unknown socket types (Silverlight 5) ***
            // *** The only defined protocol supported by Silverlight is TCP.
            //     Others can be only Unknown or Unspecified (Silverlight 5)***
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Socket args that are needed for connection
            SocketAsyncEventArgs args = new SocketAsyncEventArgs()
            {
                // Server IP and port
                RemoteEndPoint = new DnsEndPoint(host, port),
                // If policy server is hosted as TCP socket, this has to be set to SocketClientAccessPolicyProtocol.Tcp
                // If policy is stored in HTTP server, this has to be set SocketClientAccessPolicyProtocol.Http
                SocketClientAccessPolicyProtocol = SocketClientAccessPolicyProtocol.Tcp
            };
            // Set the event handler for completed connection (nomatter if it is successful or not)
            args.Completed += OnConnected;
            // Start connecting to the server asynchronously
            socket.ConnectAsync(args);
        }
        /// <summary>
        /// Even handler shot when socket connection is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnConnected(object sender, SocketAsyncEventArgs e)
        {
            // If the connection is not successful, set socket object to null
            if (e.SocketError != SocketError.Success)
            {
                if (e.SocketError == SocketError.AccessDenied)
                {
                    // Policy server is not running or cannot be reached
                    throw new SocketException((int)SocketError.AccessDenied);
                }
                socket = null;
            }
            // Begin receiving data otherwise
            else
            {
                BeginRead();
            }
        }
        /// <summary>
        /// Method for receiving data from the server
        /// </summary>
        private void BeginRead()
        {
            // Receive data only if socket is connected
            if (socket != null && socket.Connected)
            {
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                // Store the received buffer in a class variable
                args.SetBuffer(buffer, bytesReceived, buffer.Length - bytesReceived);
                // Set the event handler for received data
                args.Completed += OnReceived;
                // Start receiving data asynchronously
                socket.ReceiveAsync(args);
            }
        }
        /// <summary>
        /// Event handler shot when data is received from the server
        /// </summary>
        void OnReceived(object sender, SocketAsyncEventArgs e)
        {
            // Make sure that receiving was successful
            if (e.SocketError == SocketError.Success)
            {
                // Increase the count of received bytes in the current receiving operation
                bytesReceived += e.BytesTransferred;
            }
            // If the receiving was unsuccessful, throw an exception
            else
            {
                throw new SocketException();
            }
            // Check if the buffer is already full
            if (bytesReceived == buffer.Length)
            {
                // If the buffer is full, decode the string received from bytes
                // *** This should be your object deserialization, if you use anything but string ***
                string text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                // If the event was set from somewhere, shoot it
                // *** In most cases event is set from UI thread to handle the
                //     received string or object and show the result to user ***
                if (MessageReceived != null)
                {
                    // Shoot the event, if it's set
                    MessageReceived(this, new MessageEventArgs()
                    {
                        Message = text
                    });
                }
                // Set the bytes received count to 0, for other data receiving event to fill the buffer from begining
                bytesReceived = 0;
            }
            // Begin the data receiving again
            BeginRead();
        }
        /// <summary>
        /// Sample method to send data to the server
        /// </summary>
        /// <param name="text">Text you would like the server to receive</param>
        public void SendText(string text)
        {
            // Check if the socket is connected to the server
            if (socket != null && socket.Connected)
            {
                // Encode the string to be sent to bytes
                // *** This is where your object serialization should be done ***
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                // Check if the buffer is not empty
                if (buffer.Length != 0)
                {
                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                    // Set the buffer to be sent
                    args.SetBuffer(buffer, 0, buffer.Length);
                    // Start sending buffer to the server asynchronously
                    socket.SendAsync(args);
                }
            }
        }
    }

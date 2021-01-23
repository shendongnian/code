    public class ConnectedClient
    {
        private Socket mySocket;
        private SocketIO mySocketIO;
        private long _mySocketHandleInt64 = 0;
        // These events are pass through; ConnectedClient offers them but really
        // they are from SocketIO
        public event TCPTerminal_ConnectDel Connected
        {
            add
            {
                mySocketIO.Connected += value;
            }
            remove
            {
                mySocketIO.Connected -= value;
            }
        }
        public event TCPTerminal_DisconnectDel Disconnected
        {
            add
            {
                mySocketIO.Disconnected += value;
            }
            remove
            {
                mySocketIO.Disconnected -= value;
            }
        }
        // Own Events
        public event TCPTerminal_TxMessagePublished TxMessageReceived;
        
        public delegate void SocketFaulted(ConnectedClient cc);
        public event SocketFaulted ccSocketFaulted;
        private void OnTxMessageReceived(Socket socket, TxMessage myTxMessage)
        {
	     // process your message
        }
        private void OnMessageSent(int MessageNumber, int MessageType)
        {
		// successful send, do what you want..
        }
      
        public ConnectedClient(Socket clientSocket, ServerTerminal ParentST)
        {
            Init(clientSocket, ParentST, ReceiveMode.Handler);
        }
        public ConnectedClient(Socket clientSocket, ServerTerminal ParentST, ReceiveMode RecMode)
        {
            Init(clientSocket, ParentST, RecMode);
        }
        private void Init(Socket clientSocket, ServerTerminal ParentST, ReceiveMode RecMode)
        {
            ParentServerTerminal = ParentST;
            _myReceiveMode = RecMode;
            _FirstConnected = DateTime.Now;
            mySocket = clientSocket;
            _mySocketHandleInt64 = mySocket.Handle.ToInt64();
            mySocketIO = new SocketIO(clientSocket, RecMode);
            // Register for events
            mySocketIO.TxMessageReceived += OnTxMessageReceived;
            mySocketIO.MessageSent += OnMessageSent;
            mySocketIO.dbMessageReceived += OndbMessageReceived;
        }
        public void StartListening()
        {
            mySocketIO.StartReceiving();
        }
        public void Close()
        {
            if (mySocketIO != null)
            {
                mySocketIO.Close();
                mySocketIO = null;
            }
            try
            {
                mySocket.Close();
            }
            catch
            {
                // We're closing.. don't worry about it
            }
        }
        public void SendMessage(int MessageNumber, int MessageType, string Message)
        {
            if (mySocket != null && mySocketIO != null)
            {
                try
                {
                    mySocketIO.SendMessage(MessageNumber, MessageType, Message);
                }
                catch
                {
                    // mySocketIO disposed inbetween check and call
                }
            }
            else
            {
                // Raise socket faulted event
                if (ccSocketFaulted != null)
                    ccSocketFaulted(this);
            }
        }
    }

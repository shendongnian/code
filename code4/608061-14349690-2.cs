    public void StartListen(int port)
        {
            socketClosed = false;
            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);
            listenSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            //bind to local IP Address...
            //if ip address is allready being used write to log
            try
            {
                listenSocket.Bind(ipLocal);
            }
            catch (Exception excpt)
            {
                // Deal with this.. write your own log code here ?
                socketClosed = true;
                return;
            }
            //start listening...
            listenSocket.Listen(100); // Max 100 connections for my app
            // create the call back for any client connections...
            listenSocket.BeginAccept(new AsyncCallback(OnClientConnection), null);
        }

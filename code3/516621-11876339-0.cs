    class InternetConnector 
    { 
        private struct ConnectionData 
        { 
            public Action<Socket> SuccessHandler { get; set; } 
            public Action<Exception> ErrorHandler { get; set; } 
            public Socket Socket { get; set; } 
        } 
        public void ConnectToHost(Action<Socket> successHandler, Action<Exception> errorHandler) 
        { 
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(connector_host), connector_port); 
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            var ConnectionData = new ConnectionData 
            { 
                SuccessHandler = successHandler,
                ErrorHandler = errorHandler, 
                Socket = client 
            }; 
            client.Blocking = true; 
            client.BeginConnect(ip, new AsyncCallback(ConnectCallback), connectionData); // <--  make sure to use the lower-case connectionData here!  :)
            connectDone.WaitOne(100); 
        } 
     
        private static void ConnectCallback(IAsyncResult ar) 
        { 
            ConnectionData connectionData = new ConnectionData(); 
            try 
            { 
                connectionData = (ConnectionData)ar.AsyncState; 
                connectionData.Socket.EndConnect(ar); 
                connectDone.Set(); 
                Connected = true; 
                if (connectionData.SuccessHandler != null)
                    connectionData.SuccessHandler(connectionData.Socket);
            } 
            catch (Exception e) 
            { 
                if (connectionData.ErrorHandler != null) 
                    connectionData.ErrorHandler(e); 
            } 
        } 
    } 

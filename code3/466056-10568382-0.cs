    class HandleStationClients
    {
        // Added a field to store the value until the Start method
        TcpClient _client;
        
        public HandleStationClients(TcpClient client)
        {
            this._client = client;
            // Moved the line from here...
        }
        
        public void Start()
        {
            // ...to here.
            Task.Factory.StartNew(() => { ProcessConnection(_client); });
        }
        
        #region Event definitions
        // ...
        #endregion
    
        public async void ProcessConnection(TcpClient stationsClientSocket)
        {
            byte[] message = new byte[1024];
            int bytesRead;
    
            NetworkStream networkStream = stationsClientSocket.GetStream();
    
            if (this.ConnectionEstabilished != null)
            {
                this.ConnectionEstabilished((IPEndPoint)stationsClientSocket.Client.RemoteEndPoint);
            }
    
            while ((true))
            {
                bytesRead = 0;
    
                try
                {
                    bytesRead = await networkStream.ReadAsync(message, 0, 1024);
                }
                catch (Exception ex)
                {
                    // some error hapens here catch it                    
                    Debug.WriteLine(ex.Message);
                    break;
                }
    
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
    
                ASCIIEncoding encoder = new ASCIIEncoding();
    
                if (this.NewDataReceived != null)
                {
                    byte[] buffer = null;
    
                    string incomingMessage = encoder.GetString(message, 0, bytesRead);
    
                    this.NewDataReceived(incomingMessage);
                }
            }
            stationsClientSocket.Close();
            // Fire the disconnect Event
            // I added a line to check that ConnectionClosed isn't null
            if (this.ConnectionClosed != null)
            {
                this.ConnectionClosed();
            }
        }
    }

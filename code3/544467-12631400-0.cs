    // This is the whole actual class
    private class ConnectedClient
    {
        public TcpMessageConnection Connection { get; private set; }
        public bool ConnectedEventRaised { get; set; }
        public ConnectedClient(TcpMessageConnection connection)
        {
            this.Connection = connection;
        }
    }

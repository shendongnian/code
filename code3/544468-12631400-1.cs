    // Only class outline shown
    public class TcpMessageConnection
    {
        private readonly MessageStream messageStream; // another custom class
        private readonly TcpClient tcpClient;
        public EndPoint RemoteEndPoint { get; private set; } // who connected here?
        public MessageReader MessageReader { get; } // messageStream.Reader
        public MessageWriter MessageWriter { get; } // messageStream.Writer
        public bool IsCurrentlyDisconnecting { get; private set; }
        public void Close();
    }

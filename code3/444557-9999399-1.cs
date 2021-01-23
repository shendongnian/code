    public class TcpSocket : ISocket
    {
        private Socket socket;
        public TcpSocket()
        {
            socket = new Socket( AddressFamily.InterNetwork,
                                 SocketType.Stream, ProtocolType.Tcp );
        }
        // implement all methods of ISocket by delegating to the internal socket
    }

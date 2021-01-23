    public delegate void TcpClientConnectedEventHandler(Socket s);
    public delegate void TcpClientDisconnectedEventHandler(EndPoint ep);
    public delegate void TcpDataReceivedEventHandler(TcpPacket p);
    
    public interface ISocketTcpServerEvents
    {
        void ClientConnected;
        void ClientDisconnected;
        void DataReceived;
    }
    [ComSourceInterfaces(typeof(ISocketTcpServerEvents))]
    public class SocketTcpServer
    {   
        public event TcpClientConnectedEventHandler ClientConnected;
        public event TcpClientDisconnectedEventHandler ClientDisconnected;
        public event TcpDataReceivedEventHandler DataReceived;
        int SendToAll(byte[] buffer);
    }

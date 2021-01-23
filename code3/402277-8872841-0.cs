    public class IncomingData
    {
        Socket _Socket;
        byte[] buffer = new byte[4096];
    
        public static void Connect(IPEndPoint endPoint)
        {
            _Socket = new Socket(
                          AddressFamily.InterNetwork,
                          SocketType.Stream, 
                          ProtocolType.Tcp);        
    
            _Socket.Connect(endPoint);
    
        }
    
        public static void ReadSocket(int ReadQty)
        {
             // Wait for some data to be received. When data is received,
             // ReceiveCallback will be called.
             _Socket.BeginReceive(buffer, 0, ReadQty, SocketFlags.None, ReceiveCallback, null);
        }
    
        private static void ReceiveCallback(IAsyncResult asyncResult)
        {
            int bytesTransferred = _Socket.EndReceive(asyncResult);
            // ...
            // process the data
            // ...
        }
    }

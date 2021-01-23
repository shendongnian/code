        public class SocketPacket: IDisposable
        {
            public SocketPacket(System.Net.Sockets.Socket socket, int clientNumber, string ClientIP)
            {
                m_currentSocket = socket;
                m_clientNumber = clientNumber;
                m_ClientIP = ClientIP;
            }
            public System.Net.Sockets.Socket m_currentSocket;
            public int m_clientNumber;
            public byte[] dataBuffer = new byte[10000000];
            public string m_ClientIP;
            public void Dispose()
            {
                m_currentSocket.Dispose();
            }
        }

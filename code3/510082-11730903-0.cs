        public static TcpClient CreateTcpClient(string url)
        {
            var webRequest = WebRequest.Create(url);
            webRequest.Proxy = null;
            var webResponse = webRequest.GetResponse();
            var resposeStream = webResponse.GetResponseStream();
            const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var rsType = resposeStream.GetType();
            var connectionProperty = rsType.GetProperty("Connection", flags);
            var connection = connectionProperty.GetValue(resposeStream, null);
            var connectionType = connection.GetType();
            var networkStreamProperty = connectionType.GetProperty("NetworkStream", flags);
            var networkStream = networkStreamProperty.GetValue(connection, null);
            var nsType = networkStream.GetType();
            var socketProperty = nsType.GetProperty("Socket", flags);
            var socket = (Socket)socketProperty.GetValue(networkStream, null);
            return new TcpClient { Client = socket };
        }

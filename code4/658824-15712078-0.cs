    public class NetworkReceiver : IDisposable
    {
        private IReceiver beaconTable;
        private XmlSerializer dataDeserializer;
        private HashSet<TcpClient> ClientTable;
        private TcpListener connectionListener;
        private int bufferSize = 1000;
        public NetworkReceiver(IReceiver inputTable)
        {
            beaconTable = inputTable;
            dataDeserializer = new XmlSerializer(typeof(CommData));
            ClientTable = new HashSet<TcpClient>();
            connectionListener = new TcpListener(IPAddress.Any, SharedData.connectionPort);
            connectionListener.Start();
            connectionListener.BeginAcceptTcpClient(ListenerCallback, connectionListener);
        }
        private void ListenerCallback(IAsyncResult callbackResult)
        {
            TcpListener listener = callbackResult.AsyncState as TcpListener;
            TcpClient client;
            try
            {
                client = listener.EndAcceptTcpClient(callbackResult);
                lock (ClientTable)
                    ClientTable.Add(client);
                ClientObject clientObj = new ClientObject() { AsyncClient = client, Buffer = new byte[bufferSize] };
                client.GetStream().BeginRead(clientObj.Buffer, 0, bufferSize, ClientReadCallback, clientObj);
                listener.BeginAcceptTcpClient(ListenerCallback, listener);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }
        private void ClientReadCallback(IAsyncResult callbackResult)
        {
            ClientObject clientObj = callbackResult.AsyncState as ClientObject;
            TcpClient client = clientObj.AsyncClient;
            if (!client.Connected)
                return;
            try
            {
                int bytesRead = client.GetStream().EndRead(callbackResult);
                if (bytesRead > 0)
                {
                    MemoryStream ms = new MemoryStream(clientObj.Buffer, 0, bytesRead);
                    try
                    {
                        CommData data;
                        lock (dataDeserializer)
                            data = dataDeserializer.Deserialize(ms) as CommData;
                        lock (beaconTable)
                            beaconTable.BeaconReceived(data);
                    }
                    catch
                    { }
                    client.GetStream().BeginRead(clientObj.Buffer, 0, bufferSize, ClientReadCallback, clientObj);
                }
                else
                {
                    client.Close();
                    lock (ClientTable)
                        ClientTable.Remove(client);
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ObjectDisposedException) || ex.GetType() == typeof(InvalidOperationException))
                    return;
                else
                    throw;
            }
        }
        class ClientObject
        {
            public TcpClient AsyncClient;
            public byte[] Buffer;
        }
        public void Dispose()
        {
            connectionListener.Stop();
            foreach (TcpClient client in ClientTable)
                client.Close();
        }
    }

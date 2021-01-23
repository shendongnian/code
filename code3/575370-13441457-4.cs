    public class ChatServer : IServiceFactory
    {
        private readonly List<ClientChatConnection> _connectedClients = new List<ClientChatConnection>();
        private readonly MessagingServer _server;
        public ChatServer()
        {
            var messageFactory = new BasicMessageFactory();
            var configuration = new MessagingServerConfiguration(messageFactory);
            _server = new MessagingServer(this, configuration);
        }
        public IServerService CreateClient(EndPoint remoteEndPoint)
        {
            var client = new ClientChatConnection(this);
            client.Disconnected += OnClientDisconnect;
            lock (_connectedClients)
                _connectedClients.Add(client);
            return client;
        }
        private void OnClientDisconnect(object sender, EventArgs e)
        {
            var me = (ClientChatConnection) sender;
            me.Disconnected -= OnClientDisconnect;
            lock (_connectedClients)
                _connectedClients.Remove(me);
        }
        public void SendToAllButMe(ClientChatConnection me, ChatMessage message)
        {
            lock (_connectedClients)
            {
                foreach (var client in _connectedClients)
                {
                    if (client == me)
                        continue;
                    client.Send(message);
                }
            }
        }
        public void SendToAll(ChatMessage message)
        {
            lock (_connectedClients)
            {
                foreach (var client in _connectedClients)
                {
                    client.Send(message);
                }
            }
        }
        public void Start()
        {
            _server.Start(new IPEndPoint(IPAddress.Any, 7652));
        }
    }

    using Alchemy;
    using Alchemy.Classes;
    namespace GameServer
    {
        static class Program
        {
            public static readonly ConcurrentDictionary<ClientPeer, bool> OnlineUsers = new ConcurrentDictionary<ClientPeer, bool>();
            static void Main(string[] args)
            {
                var aServer = new WebSocketServer(4530, IPAddress.Any)
                {
                    OnReceive = context => OnReceive(context),
                    OnConnected = context => OnConnect(context),
                    OnDisconnect = context => OnDisconnect(context),
                    TimeOut = new TimeSpan(0, 10, 0),
                    FlashAccessPolicyEnabled = true
                };
            }
            private static void OnConnect(UserContext context)
            {
                var client = new ClientPeer(context);
                OnlineUsers.TryAdd(client, false);
                //Do something with the new client
            }
        }
    }

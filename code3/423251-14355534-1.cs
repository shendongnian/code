    public class FailoverServerProxy: IServer
    {
        private readonly List<ServerProxy> _servers;
        public FailoverServerProxy RegisterServer(Server server)
        {
            _servers.Add(server);
            return this;
        }
        
        // Implement interface
        public object FetchData(object param)
        {
            foreach(var server in _servers)
            {
                try
                {
                    return server.FetchData(param);
                }
                catch
                {
                    // Failed. Continue to next server in list
                    continue;
                }
            }
            
            // No more servers to try. No longer able to recover
            throw new Exception("Unable to fetch data");
        }    
    }
    public class Client
    {
        private IServer _serverProxy;
        public Client()
        {
            // Wire up main server, and its failover/retry servers
            _serverProxy = new FailoverServerProxy()
                                .RegisterServer("mainserver:2712")
                                .RegisterServer("failover1:2712")
                                .RegisterServer("failover2:2712");        
        }
        
    }

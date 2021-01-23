    // Server interface
    public interface IServer
    {
        object FetchData(object param);
    }
    public class ServerProxyBase: IServer
    {
        // Successor.
        // Alternate server to contact if the current instance fails.
        public ServerBase AlternateServerProxy { get; set; }
        // Interface
        public virtual object FetchData(object param)
        {
            if (AlternateServerProxy != null)
            {
                return AlternateServerProxy.FetchData(param);
            }
            throw new NotImplementedException("Unable to recover");
        }
    }
    // Server implementation
    public class ServerProxy : ServerProxyBase
    {
        // Interface implementation
        public override object FetchData(object param)
        {
            try
            {
                // Contact actual server and return data
                // Remoting/WCF code in here...
            }
            catch
            {
                // If fail to contact server, 
                // run base method (attempt to recover)
                return base.FetchData(param);
            }
        }
    }
    public class Client
    {
        private IServer _serverProxy;
        public Client()
        {
            // Wire up main server, and its failover/retry servers
            _serverProxy = new ServerProxy("mainserver:2712")
            {
                AlternateServerProxy = new ServerProxy("failover1:2712")
                {
                    AlternateServerProxy = new ServerProxy("failover2:2712")
                }
            };
        }
    }

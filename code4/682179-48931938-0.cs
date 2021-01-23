    // Our CUSTOM PROXY: the concrete type which will be known from main App
    [Serializable]
    public class ServerBaseProxy : MarshalByRefObject, IServerBase
    {
        private IServerBase _hostedServer;
    
        /// <summary>
        /// cstor with no parameters for deserialization
        /// </summary>
        public ServerBaseProxy ()
        {
    
        }
    
        /// <summary>
        /// Internal constructor to use when you write "new ServerBaseProxy"
        /// </summary>
        /// <param name="name"></param>
        public ServerBaseProxy(IServerBase hostedServer)
        {
            _hostedServer = hostedServer;
        }      
    
        public string Execute(Query q)
        {
            return(_hostedServer.Execute(q));
        }
    
    }

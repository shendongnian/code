    public class Properties 
    {
        public ServerProperties Server { get; private set; }
        public CustomerProperties Customer { get; private set; }
        public Properties(ServerProperties server, CustomerProperties customer)
        {
             Server = server;
             Customer = customer;
        }
     }

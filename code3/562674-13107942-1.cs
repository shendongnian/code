    public class IrcServer
    {
        public string Name { get; set; }
        public int Port { get; set; }
    
        // perhaps some methods
    }
    
    IList<IrcServer> servers = new List<IrcServer>();
    
    foreach(IrcServer server in servers)
    {
        // server.Name, server.Port
    }

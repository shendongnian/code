    public struct Server
    {
       public string ID;
       public string SiteName;
    }
    private IDictionary<string, IList<string>> servers;
    foreach(var server in GetTargetServerList()){
        if(!servers.ContainsKey(server.SiteName) {
            servers.Add(server.SiteName, new List<string>());
        }
        servers[server.SiteName].Add(server.ID);
    }

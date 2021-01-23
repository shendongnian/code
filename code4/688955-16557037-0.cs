    public struct Server
    {
       public IList<string> ServerNames;
       public string SiteName;
    }
    private IDictionary<string, IList<string>> servers;
    foreach(var server in GetTargetServerList()){
        if(servers.ContainsKey(server.SiteName) {
            servers[server.SiteName].AddRange(server.ServerNames);
        } else {
            servers.Add(server.SiteName, server.ServerNames);
        }
    }

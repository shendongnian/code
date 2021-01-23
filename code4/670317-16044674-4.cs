    var unavailableServers= new List<Server>();
    var activeServers = new List<Server>();
    var tasks = new List<Task>();
    foreach(var server in servers)
    {
        var task =
            Task.Run(() =>
                {
                    try
                    {
                        
                        server.ConnectionContext.Connect();
                        server.ConnectionContext.Disconnect();
                        activeServers.Add(server);
                    }
                    catch(ConnectionFailureException)
                    {
                        unavailableServers.Add(server);
                    }
                });
    
        tasks.Add(task);
    }
    Task.WaitAll(tasks.ToArray());

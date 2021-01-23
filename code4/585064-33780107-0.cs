    var heartBeat = GlobalHost.DependencyResolver.Resolve<ITransportHeartbeat>();
    
    var connectionAlive = heartBeat.GetConnections().FirstOrDefault(c=>c.ConnectionId == connection.ConnectionId);
    
    if (connectionAlive.IsAlive)
    {
    //Do whatever...
    }

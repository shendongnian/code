    using (var connectionHolder = serviceAConnections.Get())
    {
       var connection = connectionHolder.Connection;
       // use the connection
    }

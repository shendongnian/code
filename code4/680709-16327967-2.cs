    // Max connections is 4, interval is 200
    // Loop once to give tcp clients chance to connect
    var tcpClients = new TcpClient[_maxConnections];
    // dedicated lock object
    static readonly object lockObject = new object();

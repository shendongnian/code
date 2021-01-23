    /// <summary>
    /// Determines the most appropriate local end point to contact the provided remote end point. 
    /// Testing shows this method takes on average 1.6ms to return.
    /// </summary>
    /// <param name="remoteIPEndPoint">The remote end point</param>
    /// <returns>The selected local end point</returns>
    public static IPEndPoint BestLocalEndPoint(IPEndPoint remoteIPEndPoint)
    {    
        Socket testSocket = new Socket(remoteIPEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        testSocket.Connect(remoteIPEndPoint);
        return (IPEndPoint)testSocket.LocalEndPoint;
    }

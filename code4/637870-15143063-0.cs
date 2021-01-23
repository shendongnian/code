    foreach (TcpConnectionInformation c in connections)
    {
        if ((c.RemoteEndPoint.Port == 80) || (c.RemoteEndPoint.Port == 443))
        {
            Console.WriteLine("{0} <==> {1}:{2}",
                              c.LocalEndPoint.ToString(),
                              c.RemoteEndPoint.ToString(),
                              c.RemoteEndPoint.Port);
        }
    }

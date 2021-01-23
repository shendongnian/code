    using System.Net;
    using System.Net.Sockets;
    
    ...
    
    /// <summary>
    /// Sends a sepcified number of UDP packets to a host or IP Address.
    /// </summary>
    /// <param name="hostNameOrAddress">The host name or an IP Address to which the UDP packets will be sent.</param>
    /// <param name="destinationPort">The destination port to which the UDP packets will be sent.</param>
    /// <param name="data">The data to send in the UDP packet.</param>
    /// <param name="count">The number of UDP packets to send.</param>
    public static void SendUDPPacket(string hostNameOrAddress, int destinationPort, string data, int count)
    {
        // Validate the destination port number
        if (destinationPort < 1 || destinationPort > 65535)
            throw new ArgumentOutOfRangeException("destinationPort", "Parameter destinationPort must be between 1 and 65,535.");
    
        // Resolve the host name to an IP Address
        IPAddress[] ipAddresses = Dns.GetHostAddresses(hostNameOrAddress);
        if (ipAddresses.Length == 0)
            throw new ArgumentException("Host name or address could not be resolved.", "hostNameOrAddress");
    
        // Use the first IP Address in the list
        IPAddress destination = ipAddresses[0];            
        IPEndPoint endPoint = new IPEndPoint(destination, destinationPort);
        byte[] buffer = Encoding.ASCII.GetBytes(data);
    
        // Send the packets
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);           
        for(int i = 0; i < count; i++)
            socket.SendTo(buffer, endPoint);
        socket.Close();            
    }

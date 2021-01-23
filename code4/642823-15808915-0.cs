    int port = 1036;
    IPAddress multicastAddress = IPAddress.Parse("239.192.1.12");
    client = new UdpClient(new IPEndPoint(IPAddress.Any, port));
    
    // list of UdpClients to send multicasts
    List<UdpClient> sendClients = new List<UdpClient>();
    
    // join multicast group on all available network interfaces
    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
    
    foreach (NetworkInterface networkInterface in networkInterfaces)
    {
    	if ((!networkInterface.Supports(NetworkInterfaceComponent.IPv4)) ||
    		(networkInterface.OperationalStatus != OperationalStatus.Up))
    	{
    		continue;
    	}
    
    	IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
    	UnicastIPAddressInformationCollection unicastIPAddresses = adapterProperties.UnicastAddresses;
    	IPAddress ipAddress = null;
    	
    	foreach (UnicastIPAddressInformation unicastIPAddress in unicastIPAddresses)
    	{
    		if (unicastIPAddress.Address.AddressFamily != AddressFamily.InterNetwork)
    		{
    			continue;
    		}
    
    		ipAddress = unicastIPAddress.Address;
    		break;
    	}
    
    	if (ipAddress == null)
    	{
    		continue;
    	}
    
    	client.JoinMulticastGroup(multicastAddress, ipAddress);
    	UdpClient sendClient = new UdpClient(new IPEndPoint(ipAddress, port));
        sendClients.Add(sendClient);
    }

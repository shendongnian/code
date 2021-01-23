    public void SendTestMessage()
    {
    	foreach (IPAddress localIp in
    		Dns.GetHostAddresses(Dns.GetHostName()).Where(i => i.AddressFamily == AddressFamily.InterNetwork))
    	{
    		IPAddress ipToUse = localIp;
    		using (var mSendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
    		{
    			mSendSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
    			                            new MulticastOption(_multicastIp, localIp));
    			mSendSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 255);
    			mSendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
    			mSendSocket.MulticastLoopback = true;
    			mSendSocket.Bind(new IPEndPoint(ipToUse, _port));
    
    
    			byte[] bytes = Encoding.ASCII.GetBytes("This is my welcome message");
    			var ipep = new IPEndPoint(_multicastIp, _port);
    			mSendSocket.SendTo(bytes, ipep);
    		}
    	}
    }

    public void sendDiscoveryQuery(string local_dhcp_ip_address)
	{
		// multicast UDP-based mDNS-packet for discovering IP addresses
		System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
		socket.Bind(new IPEndPoint(IPAddress.Parse(local_dhcp_ip_address), 52634));
		IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("224.0.0.251"), 5353);
		List<byte> bytes = new List<byte>();
		
		bytes.AddRange(new byte[] { 0x0, 0x0 });  // transaction id (ignored)
		bytes.AddRange(new byte[] { 0x1, 0x0 });  // standard query
		bytes.AddRange(new byte[] { 0x0, 0x1 });  // questions
		bytes.AddRange(new byte[] { 0x0, 0x0 });  // answer RRs
		bytes.AddRange(new byte[] { 0x0, 0x0 });  // authority RRs
		bytes.AddRange(new byte[] { 0x0, 0x0 });  // additional RRs
		bytes.AddRange(new byte[] { 0x05, 0x5f, 0x68, 0x74, 0x74, 0x70, 0x04, 0x5f, 0x74, 0x63, 0x70, 0x05, 0x6c, 0x6f, 0x63, 0x61, 0x6c, 0x00, 0x00, 0x0c, 0x00, 0x01 });  // _http._tcp.local: type PTR, class IN, "QM" question
		socket.SendTo(bytes.ToArray(), endpoint);
	}

    // Listen for a connection:    	
    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Loopback, 17999);
    using (Socket listener = new Socket(IPAddress.Loopback.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
    {
        
        listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        listener.Bind(localEndPoint);
        listener.Listen(1);
        Thread t = new Thread(() =>
        {
			// Accept the connection and send a message:
            using (Socket handler = listener.Accept())
            {
				byte[] bytes = new byte[1024];
                bytes = Encoding.ASCII.GetBytes("The Message...");
                handler.Send(bytes);
			}
        });
        t.Start();
        t.Join();
    }

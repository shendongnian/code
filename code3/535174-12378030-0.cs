	listener.BeginAcceptTcpClient(OnAccept, null);
	//...
	private static void OnAccept(IAsyncResult ar)
	{
		try {
			var tcpClient = listener.EndAcceptTcpClient(ar);
			//...
		} catch(Exception ex)
		{
			Dump(ex);
			return;
		}
	}

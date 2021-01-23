	using (var tcp = new TcpClient())
	{
		var ar = tcp.BeginConnect(host, port, null, null);
		using (ar.AsyncWaitHandle)
		{
			//Wait 2 seconds for connection.
			if (ar.AsyncWaitHandle.WaitOne(2000, false))
			{
				try
				{
					tcp.EndConnect(ar);
					//Connect was successful.
				}
				catch
				{
					//EndConnect threw an exception.
					//Most likely means the server refused the connection.
				}
			}
			else
			{
				//Connection timed out.
			}
		}
	}

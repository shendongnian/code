	private void OnUdpData(IAsyncResult result)
	{
		try
		{
			byte[] data = _udpReceive.EndReceive(result, ref _receiveEndPoint);
			//Snip doing stuff with data
			_udpReceive.BeginReceive(OnUdpData, null);
		}
		catch (Exception e)
		{
			//You may also get a SocketException if you close it in a separate thread.
			if (e is ObjectDisposedException || e is SocketException)
			{
				//Log it as a trace here
				return;
			}
			//Wasn't an exception we were looking for so rethrow it.
			throw;
		}
	}

	try
	{
		NetworkStream networkStream = clientSocket.GetStream();
		networkStream.Read(bytesFrom, 0, 312);
		dataFromClient = Encoding.ASCII.GetString(bytesFrom);
		string hex = BitConverter.ToString(bytesFrom).Replace("-","");
		Console.WriteLine("\n " + hex + "\n_______________()()()______________");
	} 
	catch (InvalidOperationException ioex)
	{		
		// The TcpClient is not connected to a remote host.
	}
	catch (ObjectDisposedException odex)
	{
		// The TcpClient has been closed.
	}

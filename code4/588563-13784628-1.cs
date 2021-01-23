    	static void Main(string[] args)
		{
			TcpClient client = new TcpClient();
			TcpListener listener = new TcpListener(IPAddress.Loopback, 60123);
			listener.Start();
			while (true)
			{
				Console.WriteLine("Waiting for connection...");
				client = listener.AcceptTcpClient();
				Console.WriteLine("Connection found");
				StreamReader reader = new StreamReader(client.GetStream());
				string line = string.Empty;
				while (TestConnection(client))
				{
					line = reader.ReadLine();
					Console.WriteLine(line);
				}
				Console.WriteLine("Disconnected");
			}
		}
		private static bool TestConnection(TcpClient client)
		{
			bool sConnected = true;
			if (client.Client.Poll(0, SelectMode.SelectRead))
			{
				if (!client.Connected) sConnected = false;
				else
				{
					byte[] b = new byte[1];
					try
					{
						if (client.Client.Receive(b, SocketFlags.Peek) == 0)
						{
							// Client disconnected
							sConnected = false;
						}
					}
					catch { sConnected = false; }
				}
			}
			return sConnected;
		}

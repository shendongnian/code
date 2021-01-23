	using System;
	namespace HolePunching.Client
	{
		class Client
		{
			public const string ServerIp = "your.server.public.address";
			static void Main()
			{
				byte id = ReadIdFromConsole();
				// you need some smarter :)
				int localPort = id == 1 ? 61043 : 59912;
				var x = new Demo( ServerIp, id, localPort );
				x.Start();
			}
			private static byte ReadIdFromConsole()
			{
				Console.Write( "Peer id (1 or 2): " );
				var id = byte.Parse( Console.ReadLine() );
				Console.Title = $"Peer {id}";
				return id;
			}
		}
	}

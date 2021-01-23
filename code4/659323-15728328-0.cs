    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Globalization;
    using System.Threading;
    
    namespace TcpTunnel {
	
	public static class Program {
		
		public static void Main(String[] args) {
			
			if( args.Length != 3 ) {
				
				Console.WriteLine("<remoteAddress> <remotePort> <listenPort>");
				return;
			}
			
			ServerConfiguration config;
			
			try {
				
				config = new ServerConfiguration( args[0], args[1], args[2] );
				
			} catch(ArgumentException aex) {
				
				Console.WriteLine("<remoteAddress> <remotePort> <listenPort>");
				Console.WriteLine( aex.Message );
				return;
			}
			
			Thread serverThread = new Thread( ServerThread );
			serverThread.Start( config );
			
			Console.WriteLine("Enter \"q<enter>\" to stop program.");
			
			String line;
			while( (line = Console.ReadLine()).ToUpperInvariant() != "Q" );
			
			config.ServerSocket.Shutdown(SocketShutdown.Both);
			config.ServerSocket.Close();
		}
		
		private class ServerConfiguration {
			
			public IPAddress RemoteAddress;
			public UInt16    RemotePort;
			public UInt16    ListenPort;
			
			public ServerConfiguration(String remoteAddress, String remotePort, String listenPort) {
				
				RemoteAddress = IPAddress.Parse( remoteAddress );
				RemotePort    = UInt16   .Parse( remotePort, NumberStyles.Integer, CultureInfo.InvariantCulture );
				ListenPort    = UInt16   .Parse( listenPort, NumberStyles.Integer, CultureInfo.InvariantCulture );
			}
			
			public Boolean RunServer = true;
			
			public Socket  ServerSocket;
		}
		
		private static void ServerThread(Object configObj) {
			
			ServerConfiguration config = (ServerConfiguration)configObj;
			
			///////////////////////////////////////
			// Setup  
			
			
			
			///////////////////////////////////////
			// Wait for client
			
			Socket serverSocket = config.ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Unspecified);
			
			serverSocket.Bind( new IPEndPoint( IPAddress.Any, config.ListenPort ) );
			serverSocket.Listen(1);
			
			Console.WriteLine("Now listening for port {0}, will forward to {1}.", config.ListenPort, config.RemotePort);
			
			while( config.RunServer ) {
				
				Socket client = serverSocket.Accept();
				
				Thread clientThread = new Thread( ClientThread );
				clientThread.Start( new ClientContext() { Config = config, Client = client } );
			}
			
		}
		
		private class ClientContext {
			
			public ServerConfiguration Config;
			public Socket              Client;
		}
		
		private static void ClientThread(Object contextObj) {
			
			ClientContext context = (ClientContext)contextObj;
			
			Socket              client = context.Client;
			ServerConfiguration config = context.Config;
			
			///////////////////////////////////////
			// Connect to remote server.
			
			IPEndPoint remoteEndPoint = new IPEndPoint( config.RemoteAddress, config.RemotePort );
			
			Socket remote = new Socket( remoteEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Unspecified);
			
			remote.Connect( remoteEndPoint );
			
			///////////////////////////////////////
			// Run tunnel.
			
			Console.WriteLine("Running tunnel.");
			
			Byte[] buffer = new Byte[4096];
			
			for(;;) {
				
				if( client.Available > 0 ) {
					
					Int32 count = client.Receive( buffer );
					if( count == 0 ) return;
					
					remote.Send( buffer, count, SocketFlags.None );
				}
				
				if( remote.Available > 0 ) {
					
					Int32 count = remote.Receive( buffer );
					if( count == 0 ) return;
					
					client.Send( buffer, count, SocketFlags.None );
				}
			}
		}
		
	}
	
    }

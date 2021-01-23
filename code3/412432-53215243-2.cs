	using HolePunching.Common;
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading;
	using System.Threading.Tasks;
	namespace HolePunching.Client
	{
		public class Demo
		{
			private static bool _isRunning;
			private static UdpClient _udpPuncher;
			private static UdpClient _udpClient;
			private static UdpClient _extraUdpClient;
			private static bool _extraUdpClientConnected;
			private static byte _id;
			private static IPEndPoint _localEndPoint;
			private static IPEndPoint _serverUdpEndPoint;
			private static IPEndPoint _partnerPublicUdpEndPoint;
			private static IPEndPoint _partnerLocalUdpEndPoint;
			private static string GetLocalIp()
			{
				var host = Dns.GetHostEntry( Dns.GetHostName() );
				foreach ( var ip in host.AddressList )
				{
					if ( ip.AddressFamily == AddressFamily.InterNetwork )
					{
						return ip.ToString();
					}
				}
				throw new Exception( "Failed to get local IP" );
			}
			public Demo( string serverIp, byte id, int localPort )
			{
				_serverUdpEndPoint = new IPEndPoint( IPAddress.Parse( serverIp ), Consts.UdpPort );
				_id = id;
				// we have to bind all our UdpClients to this endpoint
				_localEndPoint = new IPEndPoint( IPAddress.Parse( GetLocalIp() ), localPort );
			}
			public void Start(  )
			{
				_udpPuncher = new UdpClient(); // this guy is just for punching
				_udpClient = new UdpClient(); // this will keep hole alive, and also can send data
				_extraUdpClient = new UdpClient(); // i think, this guy is the best option for sending data (explained below)
				InitUdpClients( new[] { _udpPuncher, _udpClient, _extraUdpClient }, _localEndPoint );
				Task.Run( (Action) SendUdpMessages );
				Task.Run( (Action) ListenUdp );
				Console.ReadLine();
				_isRunning = false;
			}
			private void InitUdpClients(IEnumerable<UdpClient> clients, EndPoint localEndPoint)
			{
				foreach ( var udpClient in clients )
				{
					udpClient.ExclusiveAddressUse = false;
					udpClient.Client.SetSocketOption( SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true );
					udpClient.Client.Bind( localEndPoint );
				}
			}
			private void SendUdpMessages()
			{
				_isRunning = true;
				var messageToServer = UdpProtocol.UdpInfoMessage.GetMessage( _id, _localEndPoint.Address, _localEndPoint.Port );
				var messageToPeer = UdpProtocol.P2PKeepAliveMessage.GetMessage();
				while ( _isRunning )
				{
					// while we dont have partner's address, we will send messages to server
					if ( _partnerPublicUdpEndPoint == null && _partnerLocalUdpEndPoint == null )
					{
						_udpPuncher.Send( messageToServer.Data, messageToServer.Data.Length, _serverUdpEndPoint );
						Console.WriteLine( $" >>> Sent UDP to server [ {_serverUdpEndPoint.Address} : {_serverUdpEndPoint.Port} ]" );
					}
					else
					{
						// you can skip it. just demonstration, that you still can send messages to server
						_udpClient.Send( messageToServer.Data, messageToServer.Data.Length, _serverUdpEndPoint );
						Console.WriteLine( $" >>> Sent UDP to server [ {_serverUdpEndPoint.Address} : {_serverUdpEndPoint.Port} ]" );
						// THIS is how we punching hole! very first this message should be dropped by partner's NAT, but it's ok.
						// i suppose that this is good idea to send this "keep-alive" messages to peer even if you are connected already,
						// because AFAIK "hole" for UDP lives ~2 minutes on NAT. so "we will let it die? NEVER!" (c)
						_udpClient.Send( messageToPeer.Data, messageToPeer.Data.Length, _partnerPublicUdpEndPoint );
						_udpClient.Send( messageToPeer.Data, messageToPeer.Data.Length, _partnerLocalUdpEndPoint );
						Console.WriteLine( $" >>> Sent UDP to peer.public [ {_partnerPublicUdpEndPoint.Address} : {_partnerPublicUdpEndPoint.Port} ]" );
						Console.WriteLine( $" >>> Sent UDP to peer.local [ {_partnerLocalUdpEndPoint.Address} : {_partnerLocalUdpEndPoint.Port} ]" );
						// "connected" UdpClient sends data much faster, 
						// so if you have something that your partner cant wait for (voice, for example), send it this way
						if ( _extraUdpClientConnected )
						{
							_extraUdpClient.Send( messageToPeer.Data, messageToPeer.Data.Length );
							Console.WriteLine( $" >>> Sent UDP to peer.received EP" );
						}
					}
					Thread.Sleep( 3000 );
				}
			}
			private async void ListenUdp()
			{
				_isRunning = true;
				while ( _isRunning )
				{
					try
					{
						// also important thing!
						// when you did not punched hole yet, you must listen incoming packets using "puncher" (later we will close it).
						// where you already have p2p connection (and "puncher" closed), use "non-puncher"
						UdpClient udpClient = _partnerPublicUdpEndPoint == null ? _udpPuncher : _udpClient;
						var receivedResults = await udpClient.ReceiveAsync();
						if ( !_isRunning )
						{
							break;
						}
						ProcessUdpMessage( receivedResults.Buffer, receivedResults.RemoteEndPoint );
					}
					catch ( SocketException ex )
					{
						// do something here...
					}
					catch ( Exception ex )
					{
						Console.WriteLine( $"Error: {ex.Message}" );
					}
				}
			}
			private static void ProcessUdpMessage( byte[] buffer, IPEndPoint remoteEndPoint )
			{
				// if server sent partner's endpoinps, we will store it and (IMPORTANT) close "puncher"
				if ( UdpProtocol.PeerAddressMessage.TryParse( buffer, out UdpProtocol.PeerAddressMessage peerAddressMessage ) )
				{
					Console.WriteLine( " <<< Got response from server" );
					_partnerPublicUdpEndPoint = new IPEndPoint( peerAddressMessage.PublicIp, peerAddressMessage.PublicPort );
					_partnerLocalUdpEndPoint = new IPEndPoint( peerAddressMessage.LocalIp, peerAddressMessage.LocalPort );
					_udpPuncher.Close();
				}
				// since we got this message we know partner's endpoint for sure, 
				// and we can "connect" UdpClient to it, so it will work faster
				else if ( UdpProtocol.P2PKeepAliveMessage.TryParse( buffer ) )
				{
					Console.WriteLine( $"           IT WORKS!!! WOW!!!  [ {remoteEndPoint.Address} : {remoteEndPoint.Port} ]" );
					_extraUdpClientConnected = true;
					_extraUdpClient.Connect( remoteEndPoint );
				}
				else
				{
					Console.WriteLine( "???" );
				}
			}
		}
	}

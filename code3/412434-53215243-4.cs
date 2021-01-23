	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Net.Sockets;
	using HolePunching.Common;
	namespace HolePunching.Server
	{
		class Server
		{
			private static bool _isRunning;
			private static UdpClient _udpClient;
			private static readonly Dictionary<byte, PeerContext> Contexts = new Dictionary<byte, PeerContext>();
			private static readonly Dictionary<byte, byte> Mappings = new Dictionary<byte, byte>
			{
				{1, 2},
				{2, 1},
			};
			static void Main()
			{
				_udpClient = new UdpClient( Consts.UdpPort );
				ListenUdp();
				Console.ReadLine();
				_isRunning = false;
			}
			private static async void ListenUdp()
			{
				_isRunning = true;
				while ( _isRunning )
				{
					try
					{
						var receivedResults = await _udpClient.ReceiveAsync();
						if ( !_isRunning )
						{
							break;
						}
						ProcessUdpMessage( receivedResults.Buffer, receivedResults.RemoteEndPoint );
					}
					catch ( Exception ex )
					{
						Console.WriteLine( $"Error: {ex.Message}" );
					}
				}
			}
			private static void ProcessUdpMessage( byte[] buffer, IPEndPoint remoteEndPoint )
			{
				if ( !UdpProtocol.UdpInfoMessage.TryParse( buffer, out UdpProtocol.UdpInfoMessage message ) )
				{
					Console.WriteLine( $" >>> Got shitty UDP [ {remoteEndPoint.Address} : {remoteEndPoint.Port} ]" );
					_udpClient.Send( new byte[] { 1 }, 1, remoteEndPoint );
					return;
				}
				Console.WriteLine( $" >>> Got UDP from {message.Id}. [ {remoteEndPoint.Address} : {remoteEndPoint.Port} ]" );
				if ( !Contexts.TryGetValue( message.Id, out PeerContext context ) )
				{
					context = new PeerContext
					{
						PeerId = message.Id,
						PublicUdpEndPoint = remoteEndPoint,
						LocalUdpEndPoint = new IPEndPoint( message.LocalIp, message.LocalPort ),
					};
					Contexts.Add( context.PeerId, context );
				}
				byte partnerId = Mappings[context.PeerId];
				if ( !Contexts.TryGetValue( partnerId, out context ) )
				{
					_udpClient.Send( new byte[] { 1 }, 1, remoteEndPoint );
					return;
				}
				var response = UdpProtocol.PeerAddressMessage.GetMessage(
					partnerId,
					context.PublicUdpEndPoint.Address,
					context.PublicUdpEndPoint.Port,
					context.LocalUdpEndPoint.Address,
					context.LocalUdpEndPoint.Port );
				_udpClient.Send( response.Data, response.Data.Length, remoteEndPoint );
				Console.WriteLine( $" <<< Responsed to {message.Id}" );
			}
		}
		public class PeerContext
		{
			public byte PeerId { get; set; }
			public IPEndPoint PublicUdpEndPoint { get; set; }
			public IPEndPoint LocalUdpEndPoint { get; set; }
		}
	}

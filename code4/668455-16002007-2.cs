    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using SocketIOClient;
    using WebSocket4Net;
    
    namespace Console_ICBIT
    {
    	public class SampleClient
    	{
    		private Client socket;
    		private IEndPointClient icbit;
    
    		private string authKey = "{your key here}";
    		private string userId = "{your user id here}";
    
    		public void Execute()
    		{
    			Console.WriteLine("Starting SocketIO4Net Client Events Example...");
    			string ioServer = string.Format("https://api.icbit.se/icbit?AuthKey={0}&UserId={1}", authKey, userId);
    			socket = new Client(ioServer);
    
    			socket.Opened += SocketOpened;
    			socket.Message += SocketMessage;
    			socket.SocketConnectionClosed += SocketConnectionClosed;
    			socket.Error += SocketError;
    
    
    			// register for 'connect' event with io server
    			socket.On("connect", (fn) =>
    									 {		// connect to namespace
    										 icbit = socket.Connect("/icbit");
    										 icbit.On("connect", (cn) => icbit.Emit("message", new { op = "subscribe", channel = "orderbook_BUM3" }));
    									 });
    			
    			// make the socket.io connection
    			socket.Connect();
    		}
    		
    		void SocketOpened(object sender, EventArgs e)
    		{
    			Console.WriteLine("SocketOpened\r\n");
    			Console.WriteLine("Connected to ICBIT API server!\r\n");
    		}
    		public void subscribe()
    		{
    			//conn.Emit("message", new { op = "subscribe", channel = "orderbook_BUH3" }); // for BTCUSD futures
    			//conn.Emit("message", "{op = 'subscribe', channel = 'orderbook_3' }"); //  for currency exchange section BTC/USD pair
    		}
    		void SocketError(object sender, ErrorEventArgs e)
    		{
    			Console.WriteLine("socket client error:");
    			Console.WriteLine(e.Message);
    		}
    
    		void SocketConnectionClosed(object sender, EventArgs e)
    		{
    			Console.WriteLine("WebSocketConnection was terminated!");
    		}
    
    		void SocketMessage(object sender, MessageEventArgs e)
    		{
    			// uncomment to show any non-registered messages
    			if (string.IsNullOrEmpty(e.Message.Event))
    				Console.WriteLine("Generic SocketMessage: {0}", e.Message.MessageText);
    			else
    				Console.WriteLine("Generic SocketMessage: {0} : {1}", e.Message.Event, e.Message.Json.ToJsonString());
    		}
    		public void Close()
    		{
    			if (this.socket != null)
    			{
    				socket.Opened -= SocketOpened;
    				socket.Message -= SocketMessage;
    				socket.SocketConnectionClosed -= SocketConnectionClosed;
    				socket.Error -= SocketError;
    				this.socket.Dispose(); // close & dispose of socket client
    			}
    		}
    	}
    }

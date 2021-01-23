    public class SampleClient
	{
		private Client socket;
		private IEndPointClient nsTarget;
		private string localSocketUrl = "http:your_url_to_socketioserver";
		
		public void Execute()
		{
			Console.WriteLine("Starting SocketIO4Net Client Events Example...");
			socket = new Client(localSocketUrl);
			socket.Opened += SocketOpened;
			socket.Message += SocketMessage;
			socket.SocketConnectionClosed += SocketConnectionClosed;
			socket.Error += SocketError;
			// register for 'connect' event with io server
			socket.On("connect", (fn) =>
			{		// connect to namespace
				nsTarget = socket.Connect("/namespacename");
				nsTarget.On("connect", (cn) => nsTarget.Emit("test", new { data = "CONNECTED" }));
				nsTarget.On("first", (message) =>
				{
					Console.WriteLine("recv [socket].[update] event");
					Console.WriteLine("  raw message:      {0}", message.RawMessage);
					Console.WriteLine("  string message:   {0}", message.MessageText);
					Console.WriteLine("  json data string: {0}", message.Json.ToJsonString());
				});
				
			});
			// make the socket.io connection
			socket.Connect();
		}
		void SocketOpened(object sender, EventArgs e)
		{
			Console.WriteLine("SocketOpened\r\n");
			Console.WriteLine("Connected to ICBIT API server!\r\n");
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

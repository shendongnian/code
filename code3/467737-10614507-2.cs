	class Test
	{
		public Test()
		{
			_channel = new TcpIO();
			_channel.DataReceived += OnDataReceived;
		}
		public void SetChannel(IDataIO channel)
		{
			_channel.SetChannel(channel);
			// Nothing will change for this "user" of DataIO
			// but now the channel used for transport will be
			// the one defined here
		}
		private void OnDataReceived(object sender, EventArgs e)
		{
			// You can use this
			byte[] data = ((IDataIO)sender).Read();
			// Or this, the sender is always the concrete
			// implementation that abstracts the strategy in use
			data = _channel.Read();
		}
		private DataIO _channel;
	}

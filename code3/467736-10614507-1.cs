	sealed class DataIO : IDataIO
	{
		public void SetChannel(IDataIO concreteChannel)
		{
			if (_concreteChannel != null)
				_concreteChannel.DataReceived -= OnDataReceived;
			_concreteChannel = concreteChannel;
			_concreteChannel.DataReceived += OnDataReceived;
		}
		public void Write(byte[] data)
		{
			_concreteChannel.Write(data);
		}
		public byte[] Read()
		{
			return _concreteChannel.Read();
		}
		public event EventHandler DataReceived;
		private IDataIO _concreteChannel;
		private void OnDataReceived(object sender, EventArgs e)
		{
			EventHandler dataReceived = DataReceived;
			if (dataReceived != null)
				dataReceived(this, e);
		}
	}
	

	public class Foo
	{
		public delegate void MyEventHandler(object source, MessageEventArgs args);
		public event MyEventHandler _event;
		public string ReadLine()
		{
			return Observable
				.FromEventPattern<MyEventHandler, MessageEventArgs>(
					h => this._event += h,
					h => this._event -= h)
				.Select(ep => ep.EventArgs.Message)
				.First();
		}
		public void SendLine(string message)
		{
			_event(this, new MessageEventArgs() { Message = message });
		}
	}
	
	public class MessageEventArgs : EventArgs
	{
		public string Message;
	}

	public IDisposable ReceiveNext(
		string clientId, string channel, Action<object> callback)
	{
		return
			messages
				.Where(message => message.Channels.Contains(channel))
				.Take(1)
				.Subscribe(message =>
					message.TryReceive(clientId, callback));
	}

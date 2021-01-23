	public IDisposable RegisterChannel(string channel, Action<object> callback)
	{
		return messages
			.Where(message => message.Channels.Contains(channel))
			.Subscribe(message => callback(message.Message));
	}

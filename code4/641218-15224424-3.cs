	internal class WrappedClient<T, TResult> : IDisposable
	{
		private readonly ChannelFactory<T> _factory;
		private readonly object _channelLock = new object();
		private T _wrappedChannel;
		public WrappedClient(ChannelFactory<T> factory)
		{
			_factory = factory;
		}
		protected T WrappedChannel
		{
			get
			{
				lock (_channelLock)
				{
					if (!Equals(_wrappedChannel, default(T)))
					{
						var state = ((ICommunicationObject)_wrappedChannel).State;
						if (state == CommunicationState.Faulted)
						{
							// channel has been faulted, we want to create a new one so clear it
							_wrappedChannel = default(T);
						}
					}
					if (Equals(_wrappedChannel, default(T)))
					{
						_wrappedChannel = _factory.CreateChannel();
					}
				}
				return _wrappedChannel;
			}
		}
		public TResult Invoke(Func<T, TResult> func)
		{
			try
			{
				return func(WrappedChannel);
			}
			catch (FaultException)
			{
				throw;
			}
			catch (CommunicationException)
			{
				// maybe retry works
				return func(WrappedChannel);
			}
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!disposing ||
			    Equals(_wrappedChannel, default(T)))
				return;
			var channel = _wrappedChannel as ICommunicationObject;
			_wrappedChannel = default(T);
			try
			{
				channel.Close();
			}
			catch (CommunicationException)
			{
				channel.Abort();
			}
			catch (TimeoutException)
			{
				channel.Abort();
			}
		}
		public void Dispose()
		{
			Dispose(true);
		}
	}

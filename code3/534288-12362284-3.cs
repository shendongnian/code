		public bool TryReceive(string clientId, Action<object> callback)
		{
			lock (receivers)
			{
				if (!receivers.Contains(clientId))
				{
					callback(this.Message);
					receivers.Add(clientId);
					return true;
				}
				else
					return false;
			}
		}

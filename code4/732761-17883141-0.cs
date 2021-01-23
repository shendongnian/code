		private void ListenForConnections() {
			Task<Socket> listentask = Task.Factory.FromAsync<Socket>(_listener.BeginAccept, _listener.EndAccept, _listener);
			listentask.ContinueWith(task => {
				if (listentask.IsFaulted) {
					//observe exception
					Exception exception = listentask.Exception;
					return;
				}
				ListenForConnections();
				var newSocket = listentask.Result;
				RaiseClientConnectedEvent(new ConnectionEventArgs(newSocket));
			});
			//don't forget to start it
			listentask.Start();
		}

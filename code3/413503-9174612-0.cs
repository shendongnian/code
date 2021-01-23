	public void Update (string msg)
	{
		// See if we need to re-invoke on the Dispatcher thread
		if (!CheckAccess())
		{
			// Invoke on the Dispatcher thread
			this.Dispatcher.BeginInvoke(new Action<string>(Update), msg);
			
			// Exit from this method to prevent continued execution
			return;
		}
		
		// We are now running on the Dispatcher thread, so we can access the UI element(s) directly
		label1.Text = msg;
	}

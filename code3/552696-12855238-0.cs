	if (this.InvokeRequired)
	{
		IAsyncResult result = BeginInvoke(new MethodInvoker(delegate()
		{
			// DOSTUFF
		}));
		// wait until invocation is completed
		EndInvoke(result);
	}
	else if (this.IsHandleCreated)
	{
		// DO STUFF
	}

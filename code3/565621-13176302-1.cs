	public void AppendLog(string msg)
	{
		if (!Dispatcher.HasThreadAccess)
			Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate { AppendLog(msg); });
		else
		{
			// DO YOUR UI STUFF
		}
	}

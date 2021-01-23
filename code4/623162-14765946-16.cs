	public void ResetTimer()
	{
		SessionTimer timer;
		if (SessionTimer.Timers.TryGetValue(Context.ConnectionId, out timer))
		{
			timer.ResetTimer();
		}
		else
		{	
			SessionTimer.StartTimer(Context.ConnectionId);
		}
	}

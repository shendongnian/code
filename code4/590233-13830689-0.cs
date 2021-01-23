	private EventWaitHandle asyncWait = new ManualResetEvent(false);
	private Timer abortTimer = null;
	private bool success = false;
	public void ReadFromTwitter()
	{
		abortTimer = new Timer(AbortTwitter, null, 50000, System.Threading.Timeout.Infinite);
		asyncWait.Reset();
		input.BeginRead(buffer, 0, buffer.Length, InputReadComplete, null);
		asyncWait.WaitOne();			
	}
	void AbortTwitter(object state)
	{
		success = false; // Redundant but explicit for clarity
		asyncWait.Set();
	}
	void InputReadComplete()
	{
		// Disable the timer:
		abortTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
		success = true;
		asyncWait.Set();
	}

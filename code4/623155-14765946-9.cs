	public class SessionTimerHub : Hub
	{
		public override Task OnConnected()
		{
			SessionTimer.StartTimer(Context.ConnectionId);
			return base.OnConnected();
		}
		public override Task OnDisconnected()
		{
			SessionTimer.StopTimer(Context.ConnectionId);
			return base.OnDisconnected();
		}
		public void ResetTimer()
		{
			SessionTimer.Timers[Context.ConnectionId].ResetTimer();
		}
	}

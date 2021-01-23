	public static class Notifier
	{
		private static context = GlobalHost.ConnectionManager.GetHubContext<SessionTimerHub>(); 
		public static void SessionTimeOut(string connectionID, int time)
		{
			context.Clients.Client(connectionID).alertClient(time);
		}
		public static void SendElapsedTime(string connectionID, int time)
		{
			context.Clients.Client(connectionID).sendElapsedTime(time);
		}
	}
	public class SessionTimerHub : Hub
	{
		public override Task OnConnected()
		{
			SessitionTimer.StartTimer(Context.ConnectionId);
			return base.OnConnected();
		}
		public override Task OnDisconnected()
		{
			SessitionTimer.StopTimer(Context.ConnectionId);
			return base.OnDisconnected();
		}
		public void ResetTimer()
		{
			SessitionTimer.Timers[Context.ConnectionId].ResetTimer();
		}
        }

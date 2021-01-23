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

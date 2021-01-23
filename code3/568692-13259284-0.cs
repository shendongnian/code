	public class Global : System.Web.HttpApplication
	{
		private static System.Threading.Timer timer;
		protected void Application_Start(object sender, EventArgs e)
		{
			var howLongTillTimerFirstGoesInMilliseconds = 1000;
			var intervalBetweenTimerEventsInMilliseconds = 2000;
			Global.timer = new Timer(
				(s) => SomeFunc(),
				null, // if you need to provide state to the function specify it here
				howLongTillTimerFirstGoesInMilliseconds,
				intervalBetweenTimerEventsInMilliseconds
			);
		}
		private void SomeFunc()
		{
			// reoccurring task code
		}
		protected void Application_End(object sender, EventArgs e)
		{
			if(Global.timer != null)
				Global.timer.Dispose();
		}
	}

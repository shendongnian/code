	public class MyClassInDependentProject : authentication
	{
		public void DoSomething(int userId, long appId)
		{
			var success = Authenticate(userId, appId);
			…
		}
	}

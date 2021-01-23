	public static class Extensions
	{
		public static void SomeExtensionMethod(this BLClass blclass, string methodname)
		{
			dynamic users = blclass.MYBLMethod();
			List<string> usernames = blclass.MYBLSecondMethod();
			foreach (string username in usernames)
			{
				var user = users[username];
				user.GetType().GetMethod(methodname).Invoke(user, null);
			}
		}
	}

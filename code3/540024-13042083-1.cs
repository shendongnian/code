        [Route("logout")]
	public class Logout { }
	public class UserService : Service
	{
		public object Any (Logout r)
		{
			this.RemoveSession();
			return this.Redirect("/login");
		}
	}

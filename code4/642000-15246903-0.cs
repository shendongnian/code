	class UserClass
	{
		public string userName;
		public Dictionary<int, string> serviceArea
	}
	UserClass user = new UserClass();
	Session["User"] = user;
	user = (UserClass)Session["User"];

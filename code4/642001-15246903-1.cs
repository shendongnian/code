	class UserClass
	{
		public string userName;
		public Dictionary<int, string> serviceArea = new Dictionary<int,string>();
	}
	UserClass user = new UserClass();
	Session["User"] = user;
	user = (UserClass)Session["User"];

	public bool IsValidUser(string userName, string passWord)
	{
		DataClasses1DataContext db = new DataClasses1DataContext();
		db.Log = System.IO.StringWriter(New StringBuilder());
		var users = from u in db.Users
					where u.name == userName
					&& u.password == passWord
					select u;
		int userCount = users.Count();
		bool isSuccess = userCount > 0;
		return isSuccess;	//Breakpoint here, check the contents of db.Log
	}

    public string UserLoginNow(string username, string password)
    {
    	string query = @"SELECT value blah.FullName FROM MyEntities.blah AS User WHERE blah.UserName = @username AND blah.Password = @password";
    	object[] parameters = new object[2];
    	parameters[0] = username;
    	parameters[1] = password;
    	using (var context = MyEntities())
    	{
    		IEnumerable<string> results = context.Database.SqlQuery<string>(query, parameters);
    		foreach (string result in results)
    		{
    		}
    	}
    }

    public void CreateUser(string userName, string friendlyName, bool makeAdministrator)
    {
    	var defaultReadOptions = new ReadOptions();
    
    	using (var client = GetCoreServiceClient())
    	{
    		var user = (UserData)client.GetDefaultData(ItemType.User, null);
    		user.Title = userName;
    		user.Description = friendlyName;
    		user.Privileges = makeAdministrator ? 1 : 0;
    		client.Create(user, defaultReadOptions);
    	}
    }

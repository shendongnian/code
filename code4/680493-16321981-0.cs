    public static List<User> Select(int userId, bool? isActive = null)
    {
        var dl = DataLayer.GetDataContext();
        var users = dl.Users.Where(x => x.ID == userID);
    	
    	if (!isActive.HasValue)
    	{
    		return users.ToList();
    	}
    	else
    	{
    		bool isActiveValue = isActive.Value;
    		return users.Where(x => x.IsActive == isActiveValue).ToList();
    	}
    }

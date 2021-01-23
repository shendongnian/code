    public void Add(User user)
    {
    	using (var context = new MyDbContext())
    	{
    		var currentUser = context.UserProfile.Single(
    			u => u.UserName == System.Web.HttpContext.Current.User.Identity.Name);
    		
    		var newUser = new User();
    		newUser.Name = user.Name;
    		newUser.Surname = user.Surname;
    		newUser.Email = user.Email;
    		newUser.CUserID = currentUser.CUserId;
    		
    		context.User.Add(newUser);
    		context.SaveChanges();
    	}
    }

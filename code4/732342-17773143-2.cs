    [HttpPost]
    public ActionResult Register(RegisterModel registerModel)
    {
    	using (var db = new DataContext())
    	{
    		// Note: this is just an example..
    		var user = new User
    		{
    			UserName = registerModel.UserName,
    			Password = registerModel.Password,
    			DepartmentId = registerModel.DepartmentId
    		}
    		
    		db.Users.Add(user);
    		db.SaveChanges();
    	}
    }

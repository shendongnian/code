    private UsersContext db = new UsersContext();
    
    public ActionResult Index(string searchUser = "")
    {
    	IEnumerable<User> result;
    	
    	if (!String.IsNullOrEmpty(searchUser))
    	{
    		var userFound = (from m in db.UserProfiles
    				   where m.UserName.Constains(searchUser)
    			       select m).FirstOrDefault(); // to take the first user you have found, but it is still an List.
                result = new List<User>() { userFound };
    	}
    	else 
    	{
    		result = (from m in db.UserProfiles
    				 select m).ToList();
    	}
        
    	return View(result); // return the type for your view
    }

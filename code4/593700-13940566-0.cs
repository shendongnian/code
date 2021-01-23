    private UsersContext db = new UsersContext();
    
    public ActionResult Index(string searchUser = "")
    {
    	IEnumerable<User> result;
    	
    	if (!String.IsNullOrEmpty(searchUser))
    	{
    		result = from m in db.UserProfiles
    				   where m.UserName.Constains(searchUser)
    			       select m;
    	}
    	else 
    	{
    		result = (from m in db.UserProfiles
    				 select m).ToList();
    	}
    
    	var user = db.UserProfiles.ToList();
    
    	return View(result); // return the type for your view
    }

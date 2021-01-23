    public ActionResult Edit(int id)
    {
    	User user = db.Users.Single(u => u.UserID == id);
    	UserViewModel model = new UserViewModel()
    	{
    		UserID = user.UserID,
    		//etc.
    	}
    	
    	ViewBag.UserGUID = new SelectList(db.Memberships, "UserId", "Password", user.UserGUID);
    	ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", user.CompanyID);
    	
    	return View(model);
    } 
    public ActionResult Edit(UserViewModel userModel)
    {
    	if (ModelState.IsValid)
    	{
    		// Update user properties
    		User user = db.Users.Single(u => u.UserID == userModel.UserID);
    		// etc.
    		
    		// If you need to update the membership value, do that next
    
    		db.SaveChanges();
    	}
    
    	ViewBag.UserGUID = new SelectList(db.Memberships, "UserId", "Password", user.UserGUID);
    	ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", user.CompanyID);
    
    	return View(user);
    }

    [HttpPost]
    public ActionResult Edit(User user)
    {
    	var u = db.Users.Single(x => x.Id == user.Id);
    	
    	if (TryUpdateModel(u))
    	{
    		u.Password = SHA512(user.Password)
    		db.SaveChanges();
    		return RedirectToAction("Index");
    	}
    	
    	return View(user);
    }

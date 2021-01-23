    [HttpPost]
    public ActionResult Edit(YourEntity model)
    {
    	try
    	{
    		yourServiceLayer.Update(User.Identity.Name, model);
    	}
    	catch (CustomSecurityException)
    	{
    		...
    	}
    }

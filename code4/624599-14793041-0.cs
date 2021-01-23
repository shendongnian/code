    public ActionResult ActionName()
    {
    	if (Request.IsAjaxRequest())
    	{
    		try
    		{
    			MyContainer context = new MyContainer();
    			
    			var result = Some Query;
    			return PartialView("_MyView", result);		
    		}
    		catch (Exception ex)
    		{
    			// return some partial error that shows some message error
    			return PartialView("_Error");
    		}
    	}
    	
    	if (User.Identity.IsAuthenticated)
    	{
    		return RedirectToAction("Index", "Home", new { area = "User" });
    	}
    	
    	return Redirect("/");
    }

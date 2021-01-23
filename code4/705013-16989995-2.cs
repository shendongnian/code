    [HttpPost]
    public ActionResult LogOn(LogOnModel model, string returnUrl)
    {
    	if (ModelState.IsValid)
    	{
    		if (Membership.ValidateUser(model.UserName, model.Password))
    		{
    			FormsAuthentication.SetAuthCookie(model.UserName, false);
    			if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
    				&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
    			{
    				return Json(new { url = returnUrl, message = "", state = "good" });
    			}
    			else
    			{
    				return Json(new { url = "/", message = "", state = "good" });
    			}
    		}
    	}
    
    	// If we got this far, something failed, redisplay form
    	return Json(new
    	{
    		url = "/",
    		errors = new
    		{
    			username = (model.UserName == null) ? "required" : "",
    			password = (model.Password == null) ? "required" : "",
    			incorrect = (!Membership.ValidateUser(model.UserName, model.Password)) ? "The user name or password provided is incorrect." : "",
    			//generic = "An error has occurred. If the error persists, please contact the webmaster."
    		},
    		state = "error"
    	});
    }

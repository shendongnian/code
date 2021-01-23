    [HttpPost]
    public ActionResult LogOn(LogOnModel model, string returnUrl)
    {
           // Do your login
    	// if success
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
    }

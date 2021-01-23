    [HttpPost]
    public ActionResult Index(LoginModel model)
    {
    	//Execute Log-in code.
        //Capture any errors and put them in the model.LoginResponse property.
    
    	return PartialView("LoginResult", model);
    }

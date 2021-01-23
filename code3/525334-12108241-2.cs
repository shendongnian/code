    public ActionResult Register()
    {    
        AccountModel vm=new AccountModel();
    
        //Not sure Why you use ViewData here.Better make it as a property
        // of your AccountModel class and pass it.
        ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
    
        return View(vm);
    }

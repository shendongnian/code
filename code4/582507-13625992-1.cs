    public ActionResult CreateUser(User user)
    {
        try
        {
           _webServiceProxy.CreateUser(user);
        }
        catch(...)
        {
           ModelState.AddModelError("", "The user name already exists");
        }
        return View();
    }
    

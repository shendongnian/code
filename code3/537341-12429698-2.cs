    [HttpPost]
    public ActionResult Admin(ViewModel model) 
    {
        var username = model.Username;
        var password = model.Password;
        Helper.CreateUser(username,password);
        return View("AdministerUsers");
    }

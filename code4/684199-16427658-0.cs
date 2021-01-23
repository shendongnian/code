    [AllowAnonymous]
    [HttpGet]
    public ActionResult Register()
    {
        ...
    }
    [AllowAnonymous]
    [HttpPost]
    public ActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // create user
            return this.RedirectToAction("SignIn");
        }
        else
        {
            return View(model);
        }
    }

    public ActionResult Index()
    {
        if (!User.IsInRole("Administrator"))
            return RedirectToAction("LogOn", "Account");
     
        return View();
    }

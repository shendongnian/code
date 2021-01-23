    public ActionResult Index()
    {
        if (User.IsInRole("administrator"))
        {
            // do something
        }
        return View();
    }

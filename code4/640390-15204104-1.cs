    public ActionResult Index()
    {
        ViewData["SomeProperty"] = "Hello";
        return View();
    }

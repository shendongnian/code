    public ActionResult Index()
    {
        TempData["SomeName"] = "Hello";
        return RedirectToAction("Details");
    }
    public ActionResult Details()
    {
        var someName = TempData["SomeName"];
    }

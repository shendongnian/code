    [HttpPost]
    public ActionResult Create()
    {
        TempData["Message"] = "Test";
        return RedirectToAction("Index");
    }
    
    public ActionResult Index() 
    {
        ViewData["Message"] = TempData["Message"];
        return View();
    }

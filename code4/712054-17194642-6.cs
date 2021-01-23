    [HttpGet]
    [ActionName("Index")]
    public ActionResult IndexGet()
    {
        return View();
    }
    
    
    [HttpPost]
    [ActionName("Index")]
    public ActionResult IndexPost()
    {
        return Json();
    }

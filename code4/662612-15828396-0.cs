    [HttpGet]
    public ActionResult Index2()  // ModelBinder doesn't fire
    {
        return View();
    }
    [HttpPost]
    public ActionResult Index2(MyListWrapper wrapper) // ModelBinder fires
    {
        return View();
    }

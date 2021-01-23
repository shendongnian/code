    public ActionResult Index()
    {     
        MyViewModel model = ...
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(MyViewModel model)
    {
        ...
    } 

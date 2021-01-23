    public ActionResult Index()
    {
        var result = GetAll().Result;
    
        return View();
    }

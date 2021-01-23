    [Authorize(Roles="SimpleUser")] or with no roles [Authorize]
    public ActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Index(FormCollection form)
    {
        ... whatever logic
        return View();
    }

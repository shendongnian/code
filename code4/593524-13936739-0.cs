    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Index(IDictionary<long?, string> someData)
    {
        if (ModelState.IsValid)
        {
            // do some stuff here...
        }
        return View();
    }

    public ActionResult Index()
    {
       return View();
    }
    
    [HttpPost]
    public ActionResult Index(dynamic input)
    {
       ViewBag.Result = input.phrase;
       return View();
    }

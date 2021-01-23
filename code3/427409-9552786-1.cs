    [HttpGet]
    public ActionResult Index()
    {
      // your code
      return View();
    }
    
    [HttpPost]
    [ActionName("Index")]
    public ActionResult IndexPost()
    {
      // your code
      return View();
    }

    public List<string> _options = new List<string>
    {
      "Opt1",
      "Opt2",
      "Opt3"
    };
    
    public ActionResult Index()
    {
      return View(_options);
    }
    
    
    [HttpPost]
    public ActionResult Index(string options)
    {
      return View(_options);
    }

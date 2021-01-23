    public ActionResult Index() 
    {
        return View();
    }
    [HttpPost]
    public ActionResult Verify(FormCollection form)
    {
        ViewBag.FormItems = form;
        return View();
    }
    [HttpPost]
    public ActionResult Accept(FormCollection form)
    {
        // Do whatever you need to do to store the data
        return View();
    }

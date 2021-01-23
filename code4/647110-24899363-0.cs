    public ActionResult Index()
    {
         Response.Headers.Add("Content-Type", "text/html");
    	 return View();
    }

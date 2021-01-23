    [HttpGet]
    public ActionResult LogIn(string dbName)
    {
        LogOnViewModel lovm = new LogOnViewModel();
        //Initalize viewmodel here
        Return view(lovm);
    }
    [HttpPost]
    public ActionResult LogIn(LogOnViewModel lovm, string dbName)
    {
        if (ModelState.IsValid) {
            //You can reference the dbName here simply by typing dbName (i.e) string test = dbName;
            //Do whatever you want here. Perhaps a redirect?
        }
        return View(lovm);
    }

    [HttpGet]
    public ActionResult LogIn()
    {
        LogOnViewModel lovm = new LogOnViewModel();
        //Initalize viewmodel here
        Return view(lovm);
    }
    [HttpPost]
    public ActionResult LogIn(LogOnViewModel lovm)
    {
        if (ModelState.IsValid) {
            string dbName= lovm.dbName;
            //Whatever you want to do with said dbName, perhaps perform a redirect?
        }
        return View(lovm);
    }

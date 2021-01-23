    public ActionResult Index()
    {
        //you can access TempData here.
    }
    
    public ActionResult SomeAction()
    {
      if (isFailed)
      {
          TempData["Failure"] = "Oops, Error";  //store to TempData
          return RedirectToAction("Index" , "Home");
      }
      return View();
     }

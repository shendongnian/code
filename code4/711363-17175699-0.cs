    public ActionResult Index(Datatype param)
    {
            
    }
    public ActionResult SomeAction()
    {
    if (isFailed) 
    {
         return RedirectToAction("Index" , "Home",new{param= value });
    }    
    return View();
    }

    public ActionResult One()
     {
       if(condition)
         return View();
       else
         RedirectToAction("Two");
     }
     public ActionResult Two()
     {
       return View();
     }

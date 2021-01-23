    public ActionResult SummerOnly()
    {
       if (!(DateTime.Now > new DateTime(2012,8,8)))
           return View("Error");    
    
       return View("GoodView");
    }

    [OutputCache(Duration = 30, VaryByParam = "none")]
    public ActionResult MyController()
    {        
        var model = GetData();
        return View(model);
    }
   

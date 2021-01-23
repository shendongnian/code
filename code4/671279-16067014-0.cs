    [HttpPost]
    public ActionResult FirstAction()
    {
        ...
        TempData["sharedData"] = data;
        return RedirectToAction("SecondAction");
    }
    
    public ActionResult SecondAction()
    {
        var data= TempData["sharedData"];
    
        return View(data);
    } 

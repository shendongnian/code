    [HttpPost]
    public ActionResult MyAction(MyViewModel model)
    { 
        if (!ModelState.IsValid)
        {
            return View(model);
        }
    
        ...
    }

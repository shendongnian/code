    [HttpGet, ActionName("Edit")]
    public ActionResult Edit(MyModel model)
    {
       return View(model);
    }
    
    [HttpPost, ActionName("Edit")]
    public ActionResult SaveEdit(MyModel model)
    {
       // validate and save, then
       return View(model);
    }

    [HttpGet]
    public ActionResult SearchAllByKey(string key)
    {
        //logic
        return View(new List<string>());
    }
    
    [HttpPost]
    public ActionResult Search(FormCollection form)
    {
        return RedirectToAction("SearchAllByKey",  new { key = form["key"] });
    }

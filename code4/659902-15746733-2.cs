    public ActionResult Create()
    {
        return View(new RawValues());
    }
    
    [HttpPost]
    public ActionResult Create(RawValues model)
    {
        if (ModelState.IsValid)
        {
            // Do stuff
        }
        else
        {
            return View(model);
        }
    }

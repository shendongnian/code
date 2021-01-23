    public ActionResult Create(RawValues model)
    {
        if (model == null)
            model = new RawValues();
        
        return View(model);
    }
    
    [HttpPost]
    public ActionResultCreate(RawValues model)
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

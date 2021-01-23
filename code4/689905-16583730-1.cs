    [HttpGet]
    public ActionResult Index(FlowViewModel model)
    {
        // ...
    }
    [HttpPost]
    public ActionResult Index(FlowViewModel model)
    {
        if (ModelState.IsValid)
        {    
            db.Gammes.Add(model.YourGammeModel);
            db.SaveChanges();
            // ...
        }
        // ...
    }

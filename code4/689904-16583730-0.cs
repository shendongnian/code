    public ActionResult Gestion(FlowViewModel model)
    {
        model.YourGammeModel = new Gamme();
        return PartialView(model);
    }
    [HttpPost]
    public ActionResult Create(FlowViewModel model)
    {
        if (ModelState.IsValid)
        {    
            db.Gammes.Add(model.YourGammeModel);
            db.SaveChanges();
            return RedirectToAction("Gestion");  
        }
        return View(model.YourGammeModel);
    }

    [HttpGet]
    public ActionResult Create()
    {
        var model = new CreateViewModel();
        model.TldDropDown = new SelectList(db.TLDs, "TLDID", "Typ");
        //model.KlienciDropDown = new SelectList(db.Klienci, "KlientID", "Firma");
        
        return View(model);
    }

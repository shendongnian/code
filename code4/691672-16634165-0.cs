    [HttpPost]
    public ActionResult Create(SwissBank swisBank) {
        if(ModelState.Isvalid)
        {
            db.SwisBank.Add(swisBank);
            db.SaceChanges()
        }
        return View();
    }

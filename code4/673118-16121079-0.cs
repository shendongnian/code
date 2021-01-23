    public ActionResult Add_Domain(int id)
    {
        ViewBag.TLDID = new SelectList(db.TLDs, "TLDID", "Typ");
        var model = new Domena { KlientID = id };
        return View(model);
    }

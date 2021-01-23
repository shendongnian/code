    public ActionResult Add_Domain(int klientID)
    {
        ViewBag.TLDID = new SelectList(db.TLDs, "TLDID", "Typ");
        var model = new Domena { KlientID = klientID };
        return View(model);
    }

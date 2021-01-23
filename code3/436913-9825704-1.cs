    //
    // GET: /Data/Update/5
    public ActionResult Update()
    {
        Data data = db.Data.Find("1");
        return View(data);
    }

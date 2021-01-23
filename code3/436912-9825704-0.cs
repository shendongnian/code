    //
    // GET: /Data/Update/5
    public ActionResult Update(string id)
    {
        Data data = db.Data.Find(id);
        return View(data);
    }

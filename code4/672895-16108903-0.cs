    public ActionResult Filter(int id)
    {
        var docs = db.GetData().Where(d => d.Id == id);
        return View("Index", docs);
    }

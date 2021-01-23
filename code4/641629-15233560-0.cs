    public ActionResult Create()
    {
        var dba = new WHFMDBContext();
        var query = dba.Categories.Select(c => new { c.Id, c.Name });
        ViewBag.Id = new SelectList(query.AsEnumerable(), "Id", "Name", 3);
        Profits p= new Profits();
        return View(p);
    }

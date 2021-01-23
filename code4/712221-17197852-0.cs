    public ActionResult Index()
    {
        var model = _db.Clients.ToList();
        return View(model);
    }

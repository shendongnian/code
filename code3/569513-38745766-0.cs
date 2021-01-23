    public ActionResult Create()
    {
        ViewBag.CostCenterId = new SelectList(db.CostCenters, "Id", "Name");
        return View();
    }

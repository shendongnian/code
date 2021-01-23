    [HttpGet]
    public ActionResult Create()
    {
        return View(new BondViewModel());
    }
    [HttpPost]
    public ActionResult Create(BondViewModel bond)
    {
        // bond.Kauf.Value should be set at this point (given it's set in the form)
        return View(bond); // fields should be re-populated
    }

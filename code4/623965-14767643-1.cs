    public ActionResult Index()
    {
        var model = new BillRate();
        model.BillRateTickets = GetTickets();
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(BillRate model)
    {
        model.BillRateTickets = GetTickets();
        return View(model);
    }

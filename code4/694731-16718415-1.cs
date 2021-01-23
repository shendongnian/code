    [ReturnJsonIfAccepted]
    public ActionResult Index()
    {
        var model = new Model(); // whatever
        return View(model);
    }

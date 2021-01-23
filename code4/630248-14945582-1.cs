    public ActionResult Index()
    {
        var model = new MyViewModel { AllHumans  =  allHuman()};
        return View(model);
    }

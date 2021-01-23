    public ActionResult Index()
    {
        FocusOnField((MyModel m) => m.IntProperty);
        return View(new MyModel());
    }

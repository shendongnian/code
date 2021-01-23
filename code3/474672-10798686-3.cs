    public ActionResult Index(int upperLimit) //I'm assuming that's where the limit is
    {
        var model = new MyModel();
        model.MyNumbers = new SelectList(Enumerable.Range(0, upperLimit + 1));
        return View(model);
    }

    public ActionResult MyAction()
    {
        var model = new MyModel();
        model.DateCreated = model.DateCreated ?? DateTime.Now;
        return View(model);
    }

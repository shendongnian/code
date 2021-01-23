    public ActionResult MyAction()
    {
        var model = new MyViewModel();
        model.SystemColor = GlobalVariables.SystemColor;
        ...
        return View(model);
    }

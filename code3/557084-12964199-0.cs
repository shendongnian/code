    [HttpGet]
    public ActionResult Output()
    {
        var model = new VTOutputModel();
        return View(model);
    }
    [HttpPost]
    public ActionResult Output(VTOutputModel model)
    {
        return PartialView("OutputPost", model);
    }

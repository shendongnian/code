    [ValidateInput(false)]
    [HttpGet]
    [NotValidateModel]
    public ActionResult Office(GestionOffice model)
    {
        model.Initialize();
        return View(model);
    }

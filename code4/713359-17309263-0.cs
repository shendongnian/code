    public ActionResult Junk()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Junk(EmployeeModal model)
    {
      bool bActive = model.Active;
      return View(model);
    }

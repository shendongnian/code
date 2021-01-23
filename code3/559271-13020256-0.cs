    [HttpPost]
    public ActionResult Index(ContactModel model)
    {
      if (ModelState.IsValid)
      {
        // Send email using Model information.
        TempData["model"] = model;
        return RedirectToAction("Gracias");
      }
      return View(model);
    }
    public ActionResult Gracias()
    {
      ContactModel model = (ContactModel)TempData["model"];
      return View(model);
    }

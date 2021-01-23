    [HttpPost]
    public ActionResult Index(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Transfer", "Home");
        }
        return View(model);
    }

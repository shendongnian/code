    [HttpPost]
    public ActionResult ProductionStepA(PS1 ps)
    {
        if (ModelState.IsValid)
        {
        }
        return View();
    }
    [HttpPost]
    public ActionResult ProductionStepB(PS2 ps)
    {
        if (ModelState.IsValid)
        {
        }
        return View();
    }

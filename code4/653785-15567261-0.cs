    [Authorize(Roles = "Coach, Admin")]
    public ActionResult Index(Somemodel model)
    {
        if (ModelState.IsValid)
        {
            dosomestuff()
        }
        return View();
    }

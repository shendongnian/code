    [HttpPost]
    public ActionResult AddMulti(multi mu)
    {
        if (ModelState.IsValid)
        {
            cat.AddMulti(mu);
            cat.Save();
            return View(mu);
        }
        else
        {
            return View(mu);
        }
    }
    [HttpGet]
    public ActionResult AddMulti(multi mu)
    {
        return View(mu);
    }

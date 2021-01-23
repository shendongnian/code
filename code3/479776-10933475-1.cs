    [HttpPost]
    public ActionResult Index(HomeViewModel home)
    {
        if (ModelState.IsValid)
        {
            int? temp = home.previousJobId2;
        }
        return View(home);
    }

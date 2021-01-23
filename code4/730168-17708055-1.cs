    [HttpPost]
    public ActionResult Create(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        // do your stuff here ...
    }

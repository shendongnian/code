    [HttpPost]
    public ActionResult Add(SomeClass model)
    {
        if (ModelState.IsValid)
        {
            ...
        }
    }

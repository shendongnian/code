    [HttpPost]
    public ActionResult MyAction(MyAction model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

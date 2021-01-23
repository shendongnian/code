    [HttpPost]
    public ActionResult Edit (Dog model)
    {
        if (ModelState.IsValid)
        {
            //He's a good dog, save him, then redirect elsewhere
        }
        else
        {
            //He's a bad dog, return the same view and the errors are shown
            return View(model);
        }
    }

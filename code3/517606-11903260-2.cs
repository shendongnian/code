    [HttpPost]
    public ActionResult Index(UserModel inputModel)
    {
        // Check to see if the model's data was valid.
        if (ModelState.IsValid)
        {
            // Do something in the database here.
            // Then redirect to give the user some feedback.
            return RedirectToAction("Thanks");
        }
        // The model validation failed so redisplay the view.
        return View(inputModel);
    }

    [HttpPost]
    public ActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
           //do stuff
           // redirect to a success page
           return RedirectToAction("Success");
        }
        // data is not valid - show the user his data and error messages
        // using Html Helper methods (see link for details)
        return View(model);
    }

    [HttpPost]
    public ActionResult Post(PersonViewModel model)
    {
        //replace EmailTurnedOff with your setting
        if (!EmailTurnedOff && string.IsNullOrWhiteSpace(model.Email))
        {
            ModelState.AddModelError("Email", "Field is Required");
        }
        
        if (ModelState.IsValid)
        {
            //do whatever
        }
        return View(model);
    }

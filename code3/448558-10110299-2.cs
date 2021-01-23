    public ActionResult DebitRequest(DebitRequestModel model) {
      var validator = new DebitRequestValidator();
      var results = validator.Validate(model);
      ModelState.AddModelErrors(results);
      if (!ModelState.IsValid)
        return View(model)
      
      //else do other stuff here
    }

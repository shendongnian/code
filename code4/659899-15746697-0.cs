    public ActionResult Create(RawValues model)
    {
      if(ModelState.IsValid)
      {
         //everything is good. Lets save and redirect
      }
      return View(model);
    }

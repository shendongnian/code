    [HttpPost]
    public ActionResult SendPayment(PrePayment model)
    {
      if(ModelState.IsValid)
      {
         //do the fun stuff
      }
      return View(model);
    }

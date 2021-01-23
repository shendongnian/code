    public ActionResult Submit(MyViewModel model)
    {
          if (ModelState.IsValid)
          {
               // model.Resources will contain selected values
          }
          return View();   
    }

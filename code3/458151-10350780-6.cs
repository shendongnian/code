    [HttpPost]
    public ActionResult Edit(EditItemViewModel model)
    {
      if(ModelState.IsValid)
      {
        //Save data 
       if(model.From=="all")
           return RedirectToAction("All");
       else
           return RedirectToAction("Focus");
      }
      return View(model);
    }

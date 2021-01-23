    [HttpPost]
    public ActionResult Edit(ItemViewModel model)
    {
      if(ModelState.IsValid)
      {
        //Save data 
       return RedirectToAction("Index");
      }
      return View(model);
    }

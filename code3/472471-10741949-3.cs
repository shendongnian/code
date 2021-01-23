    [HttpPost]
    public ActionResult Edit(YourViewModel model) {
        if (ModelState.IsValid) {
            var entity = new YourEntity(model.ID); // re-get from db
           // make your comparison here
           if(model.LastUserID != entity.LastUserID // do whatever
           ... etc...
        }
        return View(model);
    }

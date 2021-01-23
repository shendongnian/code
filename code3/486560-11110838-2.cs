    [HttpPost, ActionName("Create")]
    public ActionResult DoCreate(CreateNewsViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.category.id == 0)
            {
                // create your new category using model.category.name
            }
    
            // create an entity from the model and save to your database
    
            return RedirectToAction("Index", "News"); // do whatever you wish when you're done
        }
    
        return View("Create", model); // show Create view again if validation failed
    }

    try {
    
        //This does not pick up fluent validation failures
        if (ModelState.IsValid) {
            db.Entity.Add(entity);
            db.SaveChanges();
            //Users want to create loads of my entities without seeing the index...
            return RedirectToAction("Create");
        }
    
    } catch (DbEntityValidationException e) {
    
        //Log errors
        foreach (var result in e.EntityValidationErrors) {
            foreach(var error in result.ValidationErrors){
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    
    }
    
    //return to view with current model + validation errors 
    return View(entity)

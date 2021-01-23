    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult ProjectAdd(Database.Project model, int[] categories)
    {
        if(ModelState.IsValid) {
    
            // fill up categories
            db.InsertAndSaveProject(model, categories);
    
        }
    
        ...
    
        return redirectToView("ProjectAdd");
    }

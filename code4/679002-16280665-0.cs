    ModelState modelStateOfModel = ModelState["Model"];
    
    if (modelStateOfModel != null)
    {
        modelStateOfModel.Errors.Clear();
    }
    if (ModelState.IsValid)
    {
       ...
    }

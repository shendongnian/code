    [HttpPost]
    public ActionResult EmployerRegistration(EmployerViewModel Model)
    {
        if (ModelState.IsValid)
        {
            //do bits here
        }
        // we clear all values from the modelstate => this will ensure that
        // the helpers will use the values from the model and not those that
        // were part of the initial POST.
        ModelState.Clear();
        Model.TrackerKeys = Helper.GenerateNewNumbers(Model.TrackerKeys); 
        return View(Model);
    }

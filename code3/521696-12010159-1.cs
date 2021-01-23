    [HttpPost]
    public ActionResult EmployerRegistration(EmployerViewModel Model)
    {
        if (ModelState.IsValid)
        {
            //do bits here
        }
        for (var i = 0; i < Model.TrackerKeys.Count; i++)
        {
            ModelState.Remove(string.Format("TrackerKeys[{0}]", i));
        }
        Model.TrackerKeys = Helper.GenerateNewNumbers(Model.TrackerKeys); 
        return View(Model);
    }

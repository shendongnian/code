    public ActionResult EditSomething()
    {
        Model Model = new Model();
        Model.statusList = {some method to fill IEnumerable<status>};
        
        return View(Model);
    }

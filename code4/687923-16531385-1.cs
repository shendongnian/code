    [HttpGet]
    public ActionResult ActionMethodName()
    {
        var model = new MyViewModel();
        model.Departments = db.Departments.Where(x => (x.name != null))
                              .Select(s => new SelectListItem
                              {
                                  Value = s.name,
                                  Text = s.name
                              })
                              .Distinct(); 
         
        model.Functions = db.Functions.Where(x => (x.name != null))
                              .Select(s => new SelectListItem
                              {
                                  Value = s.name,
                                  Text = s.name
                              })
                              .Distinct(); 
        return View(model);
    }

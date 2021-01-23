    [HttpPost]
    public ActionResult Create(CreateIssueVM model)
    {
      if(ModelState.IsValid)
      {
        // save and redirect
      }
      vm.Priorities =GetPriorities();
      return View(vm);
    } 

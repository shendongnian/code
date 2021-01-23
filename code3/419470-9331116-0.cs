    [HttpPost]
    public ActionResult Create(CreateProjectViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }
    
        Project project = Mapper.Map<CreateProjectViewModel, Project>(model);
        // pass the project entity to your service layer
        _projectService.Create(project);
    
        return RedirectToAction("Index");
    }

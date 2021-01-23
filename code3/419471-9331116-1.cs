    [HttpPost]
    public ActionResult Update(CreateProjectViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }
        Project project = _projectService.GetById(model.Id);
        Mapper.Map<CreateProjectViewModel, Project>(model, project);
        // pass the project entity to your service layer
        _projectService.Update(project);
    
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Create(ProjectVM viewModel)
    {
      if(ModelState.IsValid)
      {
        //Create domain model object and set the property values and save
         Project proj=new Project();
         proj.Name=viewModel.ProjectName
         proj.ProjectOwner=viewModel.ProjectOwner;
      
         db.Projects.Add(proj);
         db.SaveChanges();
         return RedirectToAction("Created");
       }
       return View(viewModel);  //returning your view model object
    }

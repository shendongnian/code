    public ActionResult Index(string project)
        {
            var projectModel = productDB.Projects.Include("Collection");
            return View(projectModel);
        }

    public ActionResult Create()
        {
            var model = new UserDetail
            {
                ProjectDetail = db1.ProjectDetails.ToList()
            };
            return View(model);
        } 

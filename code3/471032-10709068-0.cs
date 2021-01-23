    public ActionResult Create()
    {
        var task = new Task()  { ProjectId = your_predefined_value };
        ViewBag.Projects = new SelectList(db.Projects, "Id", "Id");
        ViewData.Model = task;
        return View();
    }

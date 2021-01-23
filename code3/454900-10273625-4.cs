    public ActionResult Index()
    {
      CoursesViewModel model = new CoursesViewModel();
      model.Courses.Add(new Course { Name = "Math" });
      return View(model: model);
    }

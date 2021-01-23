    public ActionResult Index()
    {
      CoursesViewModel model = new CoursesViewModel();
      model.Courses.Add(new Course { name = "Math" });
      return View(model: model);
    }

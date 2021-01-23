    public ViewResult Index()
        {
            ServiceCourseClient client = new ServiceCourseClient();
            Course[] courses;
            courses = client.GetAllCourses();
            CourseRegisterModel model = new CourseRegisterModel();
            //model = other model population here
            model.CourseList = courses.Select(sl => new SelectListItem() 
                                              {   Text = sl.Name, 
                                                 Value = sl.CId })
                                      .ToList();
            return View(model);
        }

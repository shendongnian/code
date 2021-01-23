    public ActionResult RoleList(int id)
    {
         ViewData["MyCourse"] = FillCourseList(id);
         CourseModel model = new CourseModel();
         model.courseid= id;
         return View(model);
    }

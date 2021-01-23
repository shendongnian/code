    public ActionResult ShowCourseId(int StudentId)
    {
        ViewData.Model = from c in course.vwCourse.Where(s => s.StudentID == StudentId)
                         group c by c.CourseID into g
                         select g.FirstOrDefault();
    
        if(ViewData.Model == null || !ViewData.Model.Any())
        {
            ViewData.Model = from c in course.vwCourse
                             group c by c.CourseID into g
                             select g.FirstOrDefault();
        }
    
        return View();
    }

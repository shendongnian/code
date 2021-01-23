    public ActionResult ShowCourseId(int StudentId)
    {
        var studentCourses = (from c in course.vwCourse
                              where c.StudentID == StudentId
                              group c by c.CourseID into g
                              select g.FirstOrDefault()).ToList();
    
        if(studentCourses  == null || !studentCourses .Any())
        {
            studentCourses  = (from c in course.vwCourse
                               group c by c.CourseID into g
                               select g.FirstOrDefault()).ToList();
        }
    
        ViewData.Model = studentCourses;
        return View();
    }

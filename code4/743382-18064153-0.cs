    public JsonResult Action(string ccod, int sid)
    {
    	IEnumerable<MvcStudentTracker.Databases.Course> result = from course in db.Courses
    				join sched in db.Schedules on course.CourseCode equals sched.ClassCode
    				where sched.StuID == sid
    				select course;
    	
    	return Json(result.Any(x => x.CourseCode == ccod), JsonRequestBehavior.AllowGet);
    }

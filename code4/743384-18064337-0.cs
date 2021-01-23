     public ActionResult Action(string ccod, int sid)
            {
                IEnumerable<MvcStudentTracker.Databases.Course> result = from course in db.Courses
                            join sched in db.Schedules on course.CourseCode equals sched.ClassCode
                            where sched.StuID == sid
                            select course;
                bool permission = false;
                foreach (var item in result)
                {
                    if (item.CourseCode == ccod)
                        permission = true;
                }
        
                if (permission == false)
                {
                    //call alert dialog box "This student is not signed up for this class"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "alrt", "alert('This student is not signed up for this class');", true);
                }
                return null;
        
            }

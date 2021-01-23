    var course = SequenceByExample(new { ID = 0, CourseName = "" } );
    if (GetWebsiteCurrentMode().ToLower() == "demo")
    {
        course = from t in context.CourseTestDetails
                join c in context.Courses
                on t.CourseID equals c.ID                                  
                where t.UserID == UserID && c.IsDeleted == true
                select new
                {
                    c.ID,
                    c.CourseName
                };
    }
    else
    {
        course = from t in context.CourseTestDetails
        // ...
    }
    if(course.Any())
    {
       // ...
    }
    else
    {
        //do something different
    }

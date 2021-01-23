    public IEnumerable<CourseNames> GetCourseName()
    {
        var courses = from o in entities.UniversityCourses
                      select new { o.CourseID, o.CourseName };
        return courses.ToList() // now we have in-memory query
                      .Select(c => new CourseNames()
                      {
                         CourseID = Convert.ToInt32(c.CourseID), // OK
                         CourseName = c.CourseName
                      });
    }

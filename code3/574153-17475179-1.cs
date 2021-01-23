    public void RemoveCourse(int courseId)
    {
        using (var db = new AcademicTimetableDbContext())
        {
            var courseFromDb = db.Courses.Find(courseId);
            db.Lecturers.Load() //this is optional, it may take some time in the first load
            //Add .Local to this line
            var toRemove = db.Lecturers.Local 
                            .Where(l => l.Courses.Contains(courseFromDb)).ToList();
            foreach (var lecturer in toRemove)
            {
                lecturer.Courses.Remove(courseFromDb);
            }
            db.SaveChanges();
        }
    }

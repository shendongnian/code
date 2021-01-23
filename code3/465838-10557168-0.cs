    var results = db.Courses;
    if(!string.IsNullOrEmpty(subject))
        results = results.Where(c => c...);
    if(!string.IsNullOrEmpty(courseNumber))
       results = results.Where(c => c...);
    ...etc...

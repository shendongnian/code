    var result = db.Person
                   .Where(r=> r.EnrollmentDate != null)
                   .GroupBy(r=> r.EnrollmentDate)
                   .Select( group=> new 
                                  {
                                     EnrollmentDate = group.Key, 
                                     Count = group.Count()
                                   });

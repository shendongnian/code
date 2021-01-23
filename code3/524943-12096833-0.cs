    int count = 
    itemsQuery.Select(i => i.Assignments.OrderByDescending(a => a.DateAssigned))
              .Count(i => { var fod = i.FirstOrDefault(); 
                            return fod != null && 
                                   fod.DateReturned == null 
                          });

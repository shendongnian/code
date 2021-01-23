    var userDataList = userData.ToList();
    
    var usersList = userDataList.Select(x => x.Uder).Distinct().ToList();
    var categoriesList = userDataList.Select(x => x.Category).Distinct().ToList();   
    
    // make list of UserDataPoint with 0 sums
    var empty = (from user in users
                from category in categoriesList 
                select new UserDataPoint
                           {
                              User = user,
                              Category = category,
                              Spend = 0
                           }).ToList();     
    
    var merged = userDataList.Union(empty)
                             .GroupBy(x => new { x.User, x.Category }) // here sum up empty points with real
                             .Select(new UserDataPoint {
                                 User = group.Key.User,
                                 Category = group.Key.Category,
                                 Spend = group.Sum(y => y.Spend)
                             }).ToList();

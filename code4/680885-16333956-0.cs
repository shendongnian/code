    DateTime start = DateTime.Today.AddDays(-21);
     
    //Sample view data
    var viewsData = new[] {new {id = "id", date = new DateTime(2013, 4, 12), views = 25}};
                
    var dates = Enumerable.Range(0, 21)
                            .Select(d => start.AddDays(d))
                            .Select(n => new
                                            {
                                             Day = n,
                                             views =viewsData.Any(x => x.date == n)
                                             ? viewsData.FirstOrDefault(v => v.date == n).views
                                             : 0
                             });   

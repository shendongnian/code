    var grouping = Data.Descendants("value")
                       .GroupBy(x => x.Attribute("v").Value);
    
    var combinations grouping.SelectMany(x =>
                                  grouping.Select(y =>
                                      new { Group = x, Combination = y }));
    
    foreach(var c in combinations)
    {
        //Do Something
    }

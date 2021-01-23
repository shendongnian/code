    // Start by grouping
    var groups = table.Rows
                      .Select(r =­> new {
                          ClassID = r.Field<int>("ClassID"),
                          ClassName = r.Field<string>("ClassName"),
                          StudentID = r.Field<int>("StudentID"),
                          StudentName = r.Field<string>("StudentName")
                      })
                      .GroupBy(e => new { e.ClassID, e.ClassName });
                     
    // Then create the strings. The groups will be an IGrouping<TGroup, T> of anonymous objects but
    // intellisense will help you with that.
    foreach(var line in groups.Select(g => String.Format("{0},{1}|+{2}<br/>", 
                                           g.Key.ClassID, 
                                           g.Key.ClassName,
                                           String.Join(" and ", g.Select(e => String.Format("{0},{1}", e.StudentID, e.StudentName)))
    {
        Response.Write(line)
    }
                                      
    
                                  

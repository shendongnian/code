    var noticesGrouped = notices.GroupBy(n => n.Name).
                         Select(group =>
                             new
                             {
                                 Notice = group.Key,
                                 Count = group.Count()
                             });

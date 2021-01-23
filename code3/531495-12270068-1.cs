    var noticesGrouped = notices.GroupBy(n => n.Name).
                         Select(group =>
                             new
                             {
                                 NoticeName = group.Key,
                                 Notices = group.ToList(),
                                 Count = group.Count()
                             });

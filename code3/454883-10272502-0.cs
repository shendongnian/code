    var props = myList.GroupBy(x => x.Property)
                      .OrderByDescending(g => g.Select(x=> x.UserID)
                                               .Distinct()
                                               .Count())
                      .Select(g => g.Key);
                      .ToList();

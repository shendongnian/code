    var x = TeamDelegates.GroupBy(t => t.DelegateUserID)
                         .Select(t => new {
                                              DelegateUserID = t.Key,
                                              RepCount = t.Count()
                                          })
                         .Max(t => t.RepCount);

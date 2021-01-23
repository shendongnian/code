    var result = DbContext.UserClasses
                          .Where(x => x.Id == userClassificationId)
                          .Select(x => new 
                              {
                                  UserClassification = x,
                                  Screens = DbContext.Screens
                                                     .Where(s => !s.UserClasses.Any(u => u.Id)
                              })
                          .SingleOrDefault();

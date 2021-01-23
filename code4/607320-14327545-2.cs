    context.Users.Where(x => x.Id == 4)
                 .Select(x => new Users()
                      { 
                          Id = x.Id,
                          Name = x.Name,
                          NxEnabled = x.NxEnabled ?? false
                      });

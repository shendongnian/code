    context.Users.Where(x => x.Id = 4)
                 .Select(x => new 
                      { 
                          Id = x.Id,
                          Name = x.Name,
                          Enabled = x.NxEnabled ?? null
                      });

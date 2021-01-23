           var query = Context.Roles
                   .Include("Users")
                   .Where(r => r.ID == id)
                   .Select(r => new RoleDetail() {
                      ID = r.ID,
                      Rolename = r.Rolename,
                      Active = r.Active,
                      Users = r.Users
                               .Select(u => new RoleDetail.RoleUser() {
                                  ID = u.ID,
                                  Username = u.Username
                                })
                                // .ToList()
                    })
                   .FirstOrDefault();

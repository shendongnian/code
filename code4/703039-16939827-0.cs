            var users = new List<User>();
            var roles = new List<Role>();
            //Populate users and roles
            var rolesAndUsers = new Dictionary<Role, List<User>>();
            users.Aggregate(rolesAndUsers, (d, u) =>
                                               {
                                                   ICollection<Role> userRoles = u.UserRoles;
                                                   foreach (var userRole in userRoles)
                                                   {
                                                       if (!d.ContainsKey(userRole))
                                                           d.Add(userRole, new List<User>());
                                                       d[userRole].Add(u);
                                                   }
                                                   return d;
                                               });

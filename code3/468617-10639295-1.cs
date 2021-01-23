     StringBuilder stRoleNames = new StringBuilder();
     var user1 = dbContext.Users.Where(x => x.UserID == 34).SingleOrDefault();
     var userRoles = user1.UserRoles;
     foreach (var userRole in userRoles)
     {
         stRoleNames.Append(userRole.Role.Name);
     } 

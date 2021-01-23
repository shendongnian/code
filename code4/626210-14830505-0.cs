     foreach (var u in usersFromFile) {
        if (context.Users.Any(
              user=>
                user.EmployeeId == u.EmployeeId && user.CompanyId == 1)
           ) 
        {
            User newUser = new User();
            newUser.EmployeeId = u.EmployeeId;
            newUser.CompanyId = 1;
            context.Users.Add(newUser); //This will sometimes set CompanyId = NULL
        }
    }
    context.SaveChanges();

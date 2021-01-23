    try
    {
        IQueryable<User> users;
        var ret = null;
        using (var dataContext = new dataContext())
        {
            users = dataContext.Users.Where(x => x.AccountID == accountId && x.IsAdmin == false);
    
            if(users.Any())
            {
                ret = users.Select(x => x.ToInfo()).ToList(); 
            }
         }
    
       Return ret;
    }
    catch (Exception ex)
    {
        ...
    }

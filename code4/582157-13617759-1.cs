    try
    {
        IQueryable<User> users;
    
        using (var dataContext = new dataContext())
        {
            users = dataContext.Users.Where(x => x.AccountID == accountId && x.IsAdmin == false);
    
            if(users.Any() == false)
            {
                return null;
            }
            else
            {
                return users.Select(x => x.ToInfo()).ToList(); // this line is the problem
            }
        }
    
        
    }
    catch (Exception ex)
    {
        ...
    }

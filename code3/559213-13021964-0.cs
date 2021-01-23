    foreach (var eval in evaluations)
    {
        var user = eFactory.SYMPOSIUM_Users.Where(a => a.UserID == eval.UserID.Value 
                             && a.Active.Value && a.UserRole == 1).FirstOrDefault();
    
        if (user != null && !users.Contains(user.UserID))
        {
            users.Add(user);  
        }
    }

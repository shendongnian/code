    using (var c = new EFContext()) 
    {       
        c.Configuration.ValidateOnSaveEnabled = false; 
        Data.User u = new Data.User() { UserId = UserId };       
        c.Users.Attach(u);       
        u.FailedPasswordAttemptCount = newFailedPasswordAttemptCount;       
        c.SaveChanges(); 
    } 
    

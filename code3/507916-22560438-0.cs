     private User GetByUID(int uID, bool includeDetails = false)
     {
        var result = this.dbContext.Users.Find(uID);
        if (includeDetails)
        {
           // load user-details
           this.dbContext.Entry(result)
                         .Reference<UserDetails>(us => us.UserDetails)
                         .Load();                
        }
        return result;
     }

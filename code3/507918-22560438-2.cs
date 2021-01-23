     private User GetByUID(int uID, bool includeDetails = false, bool includeAddresses = false)
     {
        var result = context.Users.Find(uID);
        if (includeDetails)
        {
           // load user-details (1:1 relation)
           context.Entry(result)
                  .Reference<UserDetails>(us => us.UserDetails)
                  .Load();
        }
        if (includeAddresses) 
        {
           // load user-addresses (1:m relation)
           context.Entry(result)
                  .Collection(us => us.Addresses)
                  .Load();    
        }
        return result;
     }

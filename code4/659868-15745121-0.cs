    private static void GetUserData(string userName, UserSession userSession)
    {
        using (Entities ctx = CommonSERT.GetContext())
        {
            var result = (from ur in ctx.datUserRoles
                          where ur.AccountName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)
                          select new
                          {
                              UserActive = ur.active,
                              UserROB = ur.ROB,
                              UserID = ur.ID
                          }).FirstOrDefault();
            
            
        }
        if (result != null) {
            userSession.UserActive = result.UserActive;
            userSession.UserROB  = result.UserROB;
            userSession.UserID = result.UserID;
        }
              
    }

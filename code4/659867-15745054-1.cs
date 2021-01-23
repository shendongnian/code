    private static void GetUserData(string userName, UserSession user)
        {
            using (Entities ctx = CommonSERT.GetContext())
            {
                var result = (from ur in ctx.datUserRoles
                              where ur.AccountName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)
                              select new
                              {
                                  Active = ur.active,
                                  ID = ur.ID,
                                  //...select all properties from the DB
                              }).FirstOrDefault();
                if (result != null)
                    user.UserActive = result.Active;
                    user.UserID = result.ID;
                    //..set all properties of "user" object
            }
        }

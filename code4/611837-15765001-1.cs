    using (SPWeb rootWeb = topLevelSite.OpenWeb())
    {
        foreach (SPGroup group in rootWeb.Groups)
        {
            bool isUserInGroup = IsUserInGroup(group, currentUser.LoginName);
        }
    }
    private Boolean IsUserInGroup(SPGroup group, string userLoginName)
    {
        bool userIsInGroup = false;
        try
        {
            SPUser x = group.Users[userLoginName];
            userIsInGroup = true;
        }
        catch (SPException)
        {
            userIsInGroup = false;
        }
        return userIsInGroup;
    }

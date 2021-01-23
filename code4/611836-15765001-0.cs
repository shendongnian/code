    using (SPWeb rootWeb = topLevelSite.OpenWeb())
    {
        foreach (SPGroup group in rootWeb.Groups)
        {
            bool IsHe = isUserInGroup(group,currentUser.LoginName);
        }
    }
    private Boolean isUserInGroup(SPGroup oGroupName,String sUserLoginName)
    {
        Boolean bUserIsInGroup = false;
        try
        {
            SPUser x = oGroupName.Users[sUserLoginName];
            bUserIsInGroup = true;
        }
        catch (SPException)
        {
            bUserIsInGroup = false;
        }
        return bUserIsInGroup;
    }

    public static bool isAdminAuthorized()
    {
        Microsoft.SharePoint.SPContext oContext ;
        Microsoft.SharePoint.SPWeb oWeb ;
        Microsoft.SharePoint.SPUser oUser ;
        try
        {
            oContext = Microsoft.SharePoint.SPContext.Current;
        }
        catch { throw new Exception("Can't obtain Sharepoint Context!"); }
        try
        {
            oWeb = oContext.Web;
        }
        catch { throw new Exception("Can't obtain Sharepoint web!"); }
        try
        {
            oUser = oWeb.CurrentUser;
        }
        catch { throw new Exception("Can't obtain Sharepoint current user!"); }
        if (oUser == null)
        {
            Microsoft.SharePoint.Utilities.SPUtility.HandleAccessDenied(new UnauthorizedAccessException());
            oUser = oWeb.CurrentUser;
        }
        foreach (Microsoft.SharePoint.SPGroup oGroup in oUser.Groups)
        {
            if (oGroup.Name.ToUpper().Contains("OWNER"))
            {
                return true;
            }
        }
        return false;
    }

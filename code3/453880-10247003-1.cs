    SPWeb site = SPContext.Current.Web;
    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        using (SPSite ElevatedsiteColl = new SPSite(site.Url))
       {
           using (SPWeb ElevatedSite = ElevatedsiteColl.OpenWeb())
           {
                SPUser currUser = site.CurrentUser; //not the ElevatedSite.CurrentUser
           }
       }
    });

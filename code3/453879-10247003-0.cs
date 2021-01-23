    SPWeb site = SPContext.Current.Web;
    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        using (SPSite ElevatedsiteColl = new SPSite(site.ID))
       {
           using (SPWeb ElevatedSite = ElevatedsiteColl.OpenWeb())
           {
                string currUser = site.CurrentUser; //not the ElevatedSite.CurrentUser
           }
       }
    });

    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        using (SPSite site = new SPSite(web.Site.ID))
        {
           // Do things by assuming the permission of the "system account".
        }
    });

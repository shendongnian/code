    public static string GetWelcomePageUrl(SPWeb web)
        {
            if (web.DoesUserHavePermissions(SPBasePermissions.BrowseDirectories))
            {
                return web.RootFolder.WelcomePage;
            }
            string welcomePage = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite sPSite = new SPSite(web.Site.ID))
                using (SPWeb sPWeb = sPSite.OpenWeb(web.ID))
                {
                    welcomePage = sPWeb.RootFolder.WelcomePage;
                }
            });
            return welcomePage;
        }

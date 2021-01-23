    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        using (var oSiteCollection = new SPSite(properties.ListItem.Web.Url))
        {
            using (var oWebsite = oSiteCollection.RootWeb)
            {
                 var currentListItem = properties.ListItem;
                 oSiteCollection.AllowUnsafeUpdates = true;
                 oWebsite.AllowUnsafeUpdates = true;
                 currentListItem.BreakRoleInheritance(true);
                 
                 //You should take the RoleAssignments after breaking inheritance our you will be working on parents permissions. 
                 var spRoleAssColn = currentListItem.RoleAssignments;
                 oSiteCollection.AllowUnsafeUpdates = true;
                 oWebsite.AllowUnsafeUpdates = true;
                 for (int i = spRoleAssColn.Count - 1; i >= 0; i--)
                 {
                     //I think it won't allow you to remove permissions for site administrator 
                     if (spRoleAssColn[i].Member.Name != "System Account" && !oWebsite.EnsureUser(spRoleAssColn[i].Member.LoginName).IsSiteAdmin)
                     {
                        spRoleAssColn.Remove(i);
                     }
                 }
            }
        }
    });

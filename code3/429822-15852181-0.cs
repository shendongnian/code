    using (SPSite site = new SPSite("/"))
    {
        using (SPWeb web = site.OpenWeb())
        {
            SPGroup spGroupItem = web.Groups["GroupName"];
            SPRoleAssignment oRoleAssignment = web.RoleAssignments.GetAssignmentByPrincipal(spGroupItem);
    
            foreach (SPRoleDefinition inRole in oRoleAssignment.RoleDefinitionBindings)
            {
                //inRole.id //inRole.Name
                //1073741829 //limited access
            }
        }
    }

    SPWeb web = SPContext.Current.Web;
    SPGroup oGroup = web.Groups.GetByID   (oFieldUserValue.LookupId);   //Look up field value                                     
    SPPrincipal principal = (SPPrincipal)oGroup;
    SPRoleAssignment roleAssignment = new SPRoleAssignment(principal);                                        
    permFolder.Item.BreakRoleInheritance(true);                                        
    roleAssignment.RoleDefinitionBindings.Add(web.RoleDefinitions["Contribute"]);
    permFolder.Item.RoleAssignments.Add(roleAssignment);
    permFolder.Item.Update();
    finalItem.Update();  

    list.BreakRoleInheritance(true);
    SPGroup groupAdmin = web.SiteGroups["IKM Manager"];
    SPRoleAssignment roleAssignmentAdmin = new SPRoleAssignment((SPPrincipal)groupAdmin);
    SPRoleDefinition roleAdmin = web.RoleDefinitions.GetByType(SPRoleType.Administrator);
    roleAssignmentAdmin.RoleDefinitionBindings.Add(roleAdmin);
    list.RoleAssignments.Add(roleAssignmentAdmin);
    list.Update();

    SPRoleDefinition roleDefinition = web.RoleDefinitions.GetByType(SPRoleType.Contributor);
    roleAssignment.RoleDefinitionBindings.Add(roleDefinition);
    if (!myList.HasUniqueRoleAssignments)
    {
        myList.BreakRoleInheritance(true); // Ensure we don't inherit permissions from parent
    } 
    myList.RoleAssignments.Add(roleAssignment);
    myList.Update();

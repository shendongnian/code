        var roles = (SimpleRoleProvider)Roles.Provider;
        var membership = (SimpleMembershipProvider)Membership.Provider;
        if (!roles.RoleExists("Admin"))
        {
            roles.CreateRole("Admin");
        }
        if (membership.GetUser("test", false) == null)
        {
            membership.CreateUserAndAccount("test", "test");
        }
        //Commented this out because you will get a foreign key 
        //error if you try to delete the user without removing the 
        //the mapping of the user to a role
        //if (!roles.GetRolesForUser("test").Contains("Admin"))
        //{
        //    roles.AddUsersToRoles(new[] { "test" }, new[] { "admin" });
        //}
        //This will delete the user information from webpages_membership
        bool wasDeleted = membership.DeleteAccount("test");
        //This will delelet the user information form UserProfile
        wasDeleted = membership.DeleteUser("test", true);

        // Get user by name
        UserInfo user = UserInfoProvider.GetUserInfo("testUser");
        // Get user-role bindings by user's identifier
        InfoDataSet<UserRoleInfo> userRoles = UserRoleInfoProvider.GetUserRoles("UserID=" + user.UserID, null, -1, null);
        Response.Write("User: " + user.UserName + "<br /><br />");
        // Enumerate through user-role binding
        foreach (UserRoleInfo userRoleInfo in userRoles)
        {
            // Get role information based on role identifier
            RoleInfo role = RoleInfoProvider.GetRoleInfo(userRoleInfo.RoleID);
            Response.Write("User role: " + role.DisplayName + "<br />");
            // Get role-membership bindings using where condition
            InfoDataSet<MembershipRoleInfo> membershipRoles = MembershipRoleInfoProvider.GetMembershipRoles("RoleID=" + role.RoleID, null, -1, null);
            // Enumerate through role-membership bindings
            foreach (MembershipRoleInfo membershipRoleInfo in membershipRoles)
            {
                // Get membership info using identifier
                MembershipInfo membership = MembershipInfoProvider.GetMembershipInfo(membershipRoleInfo.MembershipID);
                Response.Write("Role membership: " + membership.MembershipDisplayName + "<br />");
            }
            Response.Write("<br />");
        }

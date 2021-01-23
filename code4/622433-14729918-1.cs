    public void TestPermissions(String objectName, String objectType, LoggedInUserDetails userDetails, string siteUrl)
    {
        XmlNode perms;
        XmlNode userInfo;
        XmlNode permissions;
        XmlNode rolesFromUser;
        using (SharePermissions.Permissions permissionService = new SharePermissions.Permissions())
        {
            List<object> names = new List<object>();
            permissionService.Credentials = new NetworkCredential(
                    userDetails.UserName,
                    Decrypt(userDetails.Password, "utrfirfu7j6r" + userDetails.MacAddress));
            permissionService.Url = siteUrl + @"/_vti_bin/Permissions.asmx";
            perms = permissionService.GetPermissionCollection(objectName, objectType);
        }
        using (ShareGroups.UserGroup userGroupService = new ShareGroups.UserGroup())
        {
            userGroupService.Url = siteUrl + @"/_vti_bin/UserGroup.asmx";
            userGroupService.Credentials = new NetworkCredential(
                userDetails.UserName,
                Decrypt(userDetails.Password, "asdasdasdsad" + userDetails.MacAddress));
            permissions = userGroupService.GetRolesAndPermissionsForCurrentUser();
            userInfo = userGroupService.GetUserInfo(userDetails.ResolvedUserName);
        }
    }

     private void PopulateRoleList(String userName)
     {
         string[] roleNames = Roles.GetAllRoles();
         RoleList.DataSource = roleNames;  //if this is empty, CheckBoxList is not visiblie
         RoleList.DataBind();
            foreach (string roleName in roleNames)
            {
                roleListItem.Selected = Roles.IsUserInRole(userName, roleName);
            }
        }

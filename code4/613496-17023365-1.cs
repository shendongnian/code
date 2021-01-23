     private void PopulateRoleList(String userName)
     {
         string[] roleNames = Roles.GetAllRoles();
         RoleList.DataSource = roleNames;  //if this is empty, CheckBoxList is not visiblie
         RoleList.DataBind();
         foreach (ListItem item in RoleList.Items)
         {                
              string roleName = item.Value; //Or item.Text;
              item.Selected = Roles.IsUserInRole(userName, roleName);
         }
     }

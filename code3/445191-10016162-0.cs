    DropDownList ddlRole = (DropDownList)e.Row.FindControl("ddlRole");
    
    ddlRole.DataSource = GetTruckersRoles();
    
    string[] rolesList = Roles.GetRolesForUser((string)gvTruckers.DataKeys[e.Row.RowIndex][0]);
    if (rolesList.Length > 0)
    {
        //If user is not in any roles, dont' do this
        ddlRole.SelectedValue = rolesList[0];
    }
    ddlRole.DataBind();

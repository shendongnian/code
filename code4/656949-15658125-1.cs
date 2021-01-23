    protected void rgGrid_ItemCommand(object sender, GridCommandEventArgs e)
    {
    	var userId = int.Parse(e.CommandArgument.ToString());
    
    	if (e.CommandName.Equals("Edit"))
    	{
    		Response.Redirect("~/Administrator/UserEditPanel.aspx?userId=" + userId);
    	}
    	else if (e.CommandName.Equals("Delete"))
    	{
    		HtUser.DeleteUserById(userId);
    	}
    }

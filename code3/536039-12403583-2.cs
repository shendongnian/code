    protected void GvwUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    int userId = 0;
    if (e.CommandName.Equals("DeleteUser"))
            {
                //get the user id
                userId = Convert.ToInt32(e.CommandArgument.ToString());
    
                //GetUser will delete the user
                if (DeleteUser(userId) > 0)
                {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "Delete", "alert('User Deleted.');", true);
                }
    }

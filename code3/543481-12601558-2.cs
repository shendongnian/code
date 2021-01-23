    protected void GridViewOnItemCommand(object sender, GridViewCommandEventArgs e)
    {
         var command = e.CommandName;//you can determine which button was clicked (detail or delete)
         var arg = e.CommandArgument;//you can determine which row was clicked
    }

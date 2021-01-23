    protected void GridViewOnItemCommand(object sender, GridViewCommandEventArgs e)
    {
         //you can determine which button was clicked (detail or delete)
         var command = e.CommandName;
         //you can determine which row was clicked
         var arg = e.CommandArgument;
         if(command == "Details")
              ShowDetails(arg);
         if(command == "Delete")
              Delete(arg);
    }

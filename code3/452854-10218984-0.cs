    protected void DeleteRow(object sender, EventArgs e)
    {
        var buttonClicked = sender as Button;
        var rowId = buttonClicked.CommandArgument;
        var action = buttonClicked.CommandName;
    
        // do something depending on the action and the argument
    }

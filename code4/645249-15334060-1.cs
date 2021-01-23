    private void gvUsers_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Approve":
                // Executes code to update the users table,
                // setting the approved flag to true
                // Usage: ApproveUser(integer userid);
                ApproveUser(e.CommandArgument);
                break;
            case else:
                // do whatever if the user registration wasn't approved
                break;
        }
    }

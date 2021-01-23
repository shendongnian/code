    protected void gridId_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnname")
        {
            string[] differentValues = e.CommandArgument.split("|");           
        }
    }

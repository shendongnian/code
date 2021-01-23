    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Label lblMessage = e.Item.FindControl("lblMessage") as Label;
        }
    }

    protected void rpt_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        Label label = e.Item.FindControl("lblMessage");
        LinkButton linkButton = e.Item.FindControl("Delete");
    }

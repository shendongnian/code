    protected void detailsview1_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            Response.Redirect("abc.aspx");
        }
    }

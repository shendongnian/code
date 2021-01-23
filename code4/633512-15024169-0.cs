    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlContainerControl div = e.Row.FindControl("cs1") as HtmlContainerControl;
            div.Attributes["class"] = "some_class";
        }
    }

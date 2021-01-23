    protected void GridViewServer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewServer.PageIndex = e.NewPageIndex;
        GridViewServer.Datasource = MethodReturningDataTable();
        GridViewServer.DataBind();
    }

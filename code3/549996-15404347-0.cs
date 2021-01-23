    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gridView.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(gridView, "Select$" + row.DataItemIndex, true);
            }
        }
        base.Render(writer);
    }
    
    protected void trackingDataGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridView.PageIndex = e.NewPageIndex;
        getGridViewData();
    }
    
    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int pageSize = gridView.PageSize;
            int pageIndex = gridView.PageIndex;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int newRowIndex = 0;
    
            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                rowIndex = rowIndex - newRowIndex;
            }
    
    	string valueXYZ = ((HiddenField)gridView.Rows[rowIndex].FindControl("valueXYZ")).Value;
        }
    }

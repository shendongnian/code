    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Header)
        {
             e.Row.Cells[0].ToolTip = getDynamicTooltip(0);
            // other cells ...
        }
    }

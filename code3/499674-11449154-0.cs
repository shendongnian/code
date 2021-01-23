    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        var grid = (GridView)sender;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("DropDownList1");
            DataRowView drv = (DataRowView)e.Row.DataItem;
            DataSet ds = drv.Row.Table.DataSet;
            // i'm not 100% sure what you need here, for example:
            DropDownList1.ToolTip = drv.Row.Field<int>("p_id").ToString();
        }
    }

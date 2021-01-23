     protected void GVmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        GridView gvc = (GridView)e.Row.FindControl("gvChild");
    }
    }

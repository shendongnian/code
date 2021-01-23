    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ControlType Conrol = (ControlType)e.Row.FindControl("ControlID");
            //Set the property here
        }
    }

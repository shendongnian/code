    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            YourControlType Conrol = (YourControlType)e.Row.FindControl("ControlID");
            //Set the property here
        }
    }

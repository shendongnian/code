    protected void RowDataBound(object sender, GridViewRowEventArgs e)
            {
            
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
     DropDownList code= (DropDownList)e.Row.FindControl("ddlCode") as DropDownList;
                        if (code!= null)
                        {
                           //Bind the dropdownlist
                        }
    }

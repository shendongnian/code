    protected void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            object[] dataitems = ((DataRowView)e.Row.DataItem).Row.ItemArray;
            HyperLink hl = (HyperLink)e.Row.FindControl(ControlName);
            if(hl!=null)
            {
              //write code to assing value to link
            }
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chk = new CheckBox();
            chk.EnableViewState = true;
            chk.Enabled = true;
            chk.ID = "chkb";
            e.Row.Cells[1].Controls.Add(chk);
        }
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var chk = (CheckBox)e.Row.FindControl("chkb");
            // databind it here according to the DataSource in e.Row.DataItem
        }
    }

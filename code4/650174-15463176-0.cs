    protected void GridView_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (stype.Equals("T-L"))
        {
            MyGridView.Columns[7].Visible = false;
            MyGridView.Columns[8].Visible = false;
        }
    }

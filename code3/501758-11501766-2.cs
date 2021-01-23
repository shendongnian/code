    void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row as GridViewRow;
        if (row != null)
        {
            MyObject myObject = new MyObject();
            row.Controls.Add(myObject);
        }
    }

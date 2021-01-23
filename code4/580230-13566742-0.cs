    public void radGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // do your highlighting here
            if (e.Row.Cells[1].Value.ToString() == "")
            {
                e.Row.ForeColor = Color.Red;
            }
    
        }
    }

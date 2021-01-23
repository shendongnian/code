    foreach (GridViewRow row in TaskGridView.Rows)
    {
        if (row.RowType == DataControlRowType.DataRow )
        {
           if(((CheckBox)(row.Cells[1].Controls[1])).Checked)
    
           Response.Write("," +row.Cells[1].Text);// id
    
        }
    }

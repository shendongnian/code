    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imb = (ImageButton)e.Row.FindControl("deleteButton");
    
            string recordName = e.Row.Cells[3].Text;
    
            imb.OnClientClick = "return confirm('Are You sure Want to Delete the record:-  "+ recordName.ToUpper()+" ? ');";
        }
    }

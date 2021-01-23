    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
    
            LinkButton link= (LinkButton)e.Row.Cells[4].Controls[2];
            if(db!=null){
                link.OnClientClick = "return confirm('Do you really want to delete?')",
            }
        }
    }

    protected void GridView_RowDatabound(object sender, GridViewRowEventArgs e)
            {
    
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblvalue = ((Label)e.Row.FindControl("Label3"));
    
                    // add text here
                }
            }

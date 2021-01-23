    protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType != DataControlRowType.DataRow)
        {
        	return;
        }
    
        Button button = (Button)e.Row.FindControl("btnSubmit");
    
        int Id = (int) ((DataRowView) e.Row.DataItem)["Id"];
         
        if(Id == Convert.ToInt32(Session["Id"]))
        {
            button.Enabled = false;
        }
        else
        {
            button.Enabled = true;
        }
    }

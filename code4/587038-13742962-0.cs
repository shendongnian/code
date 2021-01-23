    please try this code on gridview's event OnRowDataBound="GridView_RowDataBound"    
       protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
         {
            if ((e.Row.DataItem) != null)
            {
                Label lblStatusCode = (Label)e.row.FindControl("lblStatusCode");
                objJV.Status = Convert.ToInt32(lblStatusCode.Text);
                
            }
        }
        
    

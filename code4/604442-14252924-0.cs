    Create a rowdatabound command and place the below code. 
    
    protected void gvName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblName = (Label)row.FindControl("lblName");         
                lblName.Text = txtName.Text;  
            }
    }
        
        

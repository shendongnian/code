    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)    
    {
    
    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
    int rowIndex = gvr.RowIndex;
    
    string Cat_name = (GridView1.Rows[rowIndex].FindControl("TxtName") as TextBox).Text;
    
    }

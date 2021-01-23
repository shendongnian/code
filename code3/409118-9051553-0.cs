    void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
    
        if(e.CommandName=="REMOVE")
        {
            int orderId = Convert.ToInt32(e.CommandArgument);
            //Do Sql Here
        }
    }

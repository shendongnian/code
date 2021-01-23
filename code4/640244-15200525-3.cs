    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "OnDelete")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            // now you got the rowindex, write your deleting logic here.
        }
    } 

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "OnDelete")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            // now you got the rowindex, write your deleting logic here.
            int ID = Convert.ToInt32(myGrid.DataKeys[rowIndex]["ID"].Value);
            // id will return you the id of the row you want to delete 
        }
    } 

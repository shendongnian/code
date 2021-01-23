    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "OnDelete")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            // now you got the rowindex, write your deleting logic here.
            int ID = Convert.ToInt32(myGrid.DataKeys[rowIndex]["ID"].Value);
            // id will return you the id of the row you want to delete 
            TextBox tb = (TextBox)GridView1.Rows[rowIndex].FindControl("textboxid");
            string text = tb.Text;
            // This way you can find and fetch the properties of controls inside a `GridView`. Just that it should be within `ItemTemplate`.
        }
    } 

    protected void griditems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = (DataTable)Session["table"];
    
        //Update the values.           
        GridViewRow row = griditems.Rows[e.RowIndex];
        dt.Rows[row.DataItemIndex]["Part"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Quantity"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Ship-To"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Requested Date"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Shipping Method"] = ((DropDownList)(row.Cells[5].Controls[0])).SelectedItem.ToString();
    
    
        //Reset the edit index.
        griditems.EditIndex = -1;
        //Bind data to the GridView control.
        BindData();
    
        Session["table"] = dt; 
    }

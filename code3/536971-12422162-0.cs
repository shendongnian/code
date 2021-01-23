    protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {    
        //Retrieve the table from the session object.
        DataTable dt = (DataTable)Session["TaskTable"];
    
        //Update the values.
        GridViewRow row = TaskGridView.Rows[e.RowIndex];
        dt.Rows[row.DataItemIndex]["Id"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Description"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["IsComplete"] = ((CheckBox)(row.Cells[3].Controls[0])).Checked;
    
        //Reset the edit index.
        TaskGridView.EditIndex = -1;
    
        //Bind data to the GridView control.
        BindData();
      }

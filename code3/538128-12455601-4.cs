    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {    
    
       //Update the values.
       GridViewRow row = GridView.Rows[e.RowIndex];
       var monthName = ((TextBox)(row.Cells[1].Controls[0])).Text;
       var monthNumber = GetMonthNumber(monthName);
   
      // code to update your dataset or database with month number 
      //Reset the edit index.
      GridView.EditIndex = -1;
      //Bind data to the GridView control.
      BindData();
    }
   

     void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
    
        // If multiple ButtonField column fields are used, use the
        // CommandName property to determine which button was clicked.
        if(e.CommandName=="Select")
        {
       // Convert the row index stored in the CommandArgument
          // property to an Integer.
          int index = Convert.ToInt32(e.CommandArgument);    
    
          // Get the last name of the selected author from the appropriate
          // cell in the GridView control.
          GridViewRow selectedRow = CustomersGridView.Rows[index];
        
       }
    }

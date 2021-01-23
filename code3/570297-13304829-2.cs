    void CustomersGridView_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
      {
    
        // Get the currently selected row.
        //Because the SelectedIndexChanging event occurs  before the select operation
        //in the GridView control, the SelectedRow property cannot be used.
        //Instead, use the Rows collection
        //and the NewSelectedIndex property of the 
        //e argument passed to this event handler.
     
        GridViewRow row = CustomersGridView.Rows[e.NewSelectedIndex];
    
        //Cells[0] is for first column so assign according to your column for ID
        Session["IDs"]=row.Cells[0].Text;
       
    
      }

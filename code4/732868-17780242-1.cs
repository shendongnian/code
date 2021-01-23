    void CustomersGridView_SelectedIndexChanged(Object sender, EventArgs e)
      {
    
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = CustomersGridView.SelectedRow;
        MessageLabel.Text = "You selected " + row.Cells[2].Text; // just for Display
    
      }

     void CustomersGridView_SelectedIndexChanged(Object sender, EventArgs e)
      {
    
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = CustomersGridView.SelectedRow;
        MessageLabel.Text = "You selected " + row.Cells[2].Text + ".";
    
      }
    
      void CustomersGridView_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
      {
    
        // SelectedIndexChanging event occurs before the select operation in the GridView control, the
        // SelectedRow property cannot be used. Instead, use the Rows collection
        // and the NewSelectedIndex property of the e argument passed to this 
        // event handler.
        GridViewRow row = CustomersGridView.Rows[e.NewSelectedIndex];
        // here you can check the checkbox, by accessing it in template column using findControl method 
         CheckBox chk = (CheckBox) CustomersGridview.FindControl("chkboxID"); 
        chk.checked;    
        
        if (row.Cells[1].Text == "SomeCondition")
        {
    
          e.Cancel = true;
          MessageLabel.Text = "You cannot select " + row.Cells[2].Text + ".";
    
        }
    
      }

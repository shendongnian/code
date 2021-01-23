    void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        if(e.CommandName=="Select")
        {
          int index = Convert.ToInt32(e.CommandArgument);    
          GridViewRow selectedRow = CustomersGridView.Rows[index];
          TableCell contactName = selectedRow.Cells[1];
          string contact = contactName.Text;  
          Message.Text = "You selected " + contact + ".";
        }
      }

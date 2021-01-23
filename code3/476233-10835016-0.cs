     private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
     {
          e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
     }
    
     void Control_KeyPress(object sender, KeyPressEventArgs e)
     {
          if (e.KeyChar == 44)
          {
               e.Handled = true;
          }
     }

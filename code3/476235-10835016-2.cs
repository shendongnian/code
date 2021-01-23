      private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
      {
          if (e.Control is TextBox)
          {
              e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
           }
       }

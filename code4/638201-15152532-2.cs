    private void dataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
      // here you need to attach the on key press event to handle validation
      DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
      tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
      e.Control.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
    }

    private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      // when user did not entered a number
      if (!Char.IsNumber(e.KeyChar)
            && (Keys)e.KeyChar != Keys.Back)  // check if backspace is pressed
      {
        // set handled to cancel the event to be proceed by the system
        e.Handled = true;
        // optionally indicate user that characters other than numbers are not allowed
        // MessageBox.Show("Only numbers are allowed");
      }
    }

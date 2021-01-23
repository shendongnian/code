    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
      {
        e.Handled = true;
        MessageBox.Show("Try not to delete... write freely and openly");
        // Does not show message box...
      }
    }
    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
       richTextBox1.SelectionProtected = richTextBox1.SelectionLength > 0;
    }

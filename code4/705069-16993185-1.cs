    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
        {
            e.Handled = true;
            MessageBox.Show("Delete Pressed");
            // Does not show message box...
        }
    }

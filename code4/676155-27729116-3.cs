    private void tbUsername_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            if (sender != null)
                ((TextBox)sender).SelectAll();
        }
    }

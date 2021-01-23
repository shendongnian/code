    private void tbUsername_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && e.Control)
        {
            tbUsername.SelectAll();
        }
    }

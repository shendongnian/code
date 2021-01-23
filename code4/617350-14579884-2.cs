    private void Form_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.L)
        {
                yourButton.PerformClick();
                e.Handled = true;
        }
    }

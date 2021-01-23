    private void TxtBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar))
            { e.Handled = true; }
            else
            {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter)
            { e.Handled = false; }
            }
        }

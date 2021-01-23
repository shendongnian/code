    private void TxtBox5_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
            { e.Handled = true; }
    }

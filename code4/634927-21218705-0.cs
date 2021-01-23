    private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar!='.')
        {
            e.Handled = true;
        }
        if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
        {
            e.Handled = true;
        }
    }

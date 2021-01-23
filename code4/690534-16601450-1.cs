    private void txtLocl_KeyPress(object sender, KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        if (e.KeyChar!=(char)Keys.Back)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (!Char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

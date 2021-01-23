    if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
    {
        e.Handled = false;
    }
    else
    {
        e.Handled = true;
    }

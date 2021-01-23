    if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) 
    | e.KeyChar == decSeperator))
    {
        e.Handled = true;
    }
    // only allow one decimal point
    if (e.KeyChar == decSeperator
        && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
    {
        e.Handled = true;
    }
    
    

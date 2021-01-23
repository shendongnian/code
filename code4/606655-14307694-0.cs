    if(e.KeyChar != ',' && e.KeyChar != '.')
    {
        if (char.IsPunctuation(e.KeyChar))
        {
             e.Handled = true;
        }
        
        if (char.IsSymbol(e.KeyChar))
        {
             e.Handled = true;
        }
    }

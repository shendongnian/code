    const char Backspace = '\u0008';
    const char Delete = '\u007f';
    
    if (!Char.IsDigit(e.KeyChar)    // Allow 0-9
        && e.KeyChar != Backspace   // Allow backspace key
        && e.KeyChar != Delete)     // Allow delete key
    {
        e.Handled = true;
        return;
    }

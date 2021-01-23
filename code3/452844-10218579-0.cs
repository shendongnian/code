    KeysConverter kc = new KeysConverter();
    if (!Char.IsControl(Convert.ToChar(kc.ConvertToString(e.KeyCode))))
    {
        ...
    }

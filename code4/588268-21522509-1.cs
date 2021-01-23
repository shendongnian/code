    try
    {
        short charCode = (short)Strings.Asc(e.KeyChar);
        string validinput = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-0123456789 .";
        if (Strings.InStr(validamt, Conversions.ToString(Strings.Chr(charCode)), Microsoft.VisualBasic.CompareMethod.Binary) == 0)
        {
            charCode = 0;
        }
        if (charCode == 0)
        {
            e.Handled = true;
        }
    }

    for (int i = 0; i < str.Length; i++)
    {
        if (char.IsDigit(str[i]))
        {
            break;
        }
        str = string.Substring(1);
    }
    for (int i = str.Length - 1; i > 0; i--)
    {
        if (char.IsDigit(str[i]))
        {
            break;
        }
        str = string.Substring(0, str.Length - 1);
    }

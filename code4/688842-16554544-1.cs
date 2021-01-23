    string b64stock; // <- long one
    int b = 0;
    StringBuilder sb = new StringBuilder(b64Stock.Length);
    foreach (char c in b64Stock)
    {
        int asciiChar = (int)c;
        if ((b % 2) == 0)
        {
            asciichar += 5;
        }
        else
        {
            asciichar -= 5;
        }
        sb.Append((char)asciichar);
        b++;
    }
    string b64readable = sb.ToString();

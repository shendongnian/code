    string GetDigits(string s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var c in s)
        {
            if (Char.IsDigit(c))
                sb.Append(c);
        }
        return sb.ToString();
    }

    private string TextOnly(String input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Char c in input)
            if (!Char.IsDigit(c))
                sb.Append(c);
        return sb.ToString();
    }

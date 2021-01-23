    var sb = new StringBuilder();
    for (int i = TotalLength.Length - 1; i >= 0; i--)
    {
        sb.Append("\\x");
        sb.Append(TotalLength[i].ToString("x2"));
    }
    string hex = sb.ToString();

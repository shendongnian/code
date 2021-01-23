    var sb = new StringBuilder();
    foreach (byte byteValue in TotalLength)
    {
        sb.Append("\\x");
        sb.Append(byteValue.ToString("x2"));
    }
    string hex = sb.ToString();

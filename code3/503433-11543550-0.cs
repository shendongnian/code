    var sb = new StringBuilder();
    foreach (var c in str)
    {
        if (c >= 32 && c <= 175)
        {
            sb.Append(c);
        }
    }
    var str2 = str.ToString();

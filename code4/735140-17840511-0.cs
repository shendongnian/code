    var stringBuilder = new StringBuilder();
    for (int i = 0; i < Math.Max(s1.Length, s2.Length); i++)
    {
        if (i < s1.Length)
            stringBuilder.Append(s1[i]);
        if (i < s2.Length)
            stringBuilder.Append(s2[i]);
    }
    string result = stringBuilder.ToString();
